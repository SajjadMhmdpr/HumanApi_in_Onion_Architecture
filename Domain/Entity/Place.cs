using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Place
    {
        public int Id { get; set; }
        [ForeignKey(nameof(HumanId))]
        public Human? Human { get; set; }
        public int? HumanId { get; set; }
        [MaxLength(500)]
        public string? Address { get; set; }
    }
}
