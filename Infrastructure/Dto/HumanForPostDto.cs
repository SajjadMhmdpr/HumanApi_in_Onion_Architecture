
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class HumanForPostDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Family { get; set; }
        [MaxLength(300)]
        public string? Avatar { get; set; }
        public List<IFormFile>  Images { get; set; } = new List<IFormFile>();
        public List<string> Addresses { get; set; } = new List<string>();
    }
}
