using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Img
    {
        public int Id { get; set; }
        [ForeignKey("HumanId")]
        public Human? Human { get; set; }
        public int? HumanId { get; set; }
        [MaxLength(300)]
        public string? Path { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
