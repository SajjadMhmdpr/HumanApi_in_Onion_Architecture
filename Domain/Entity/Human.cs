using Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Human : BaseEntity
    {
        public Human() {
            Id = new int();
            AddedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Family { get; set; }
        public string Avatar { get; set; }
        public virtual ICollection<Img> Images { get; set; } = new List<Img>();
        public virtual ICollection<Place> Addresses { get; set; }=new List<Place>();
    }

 
}
