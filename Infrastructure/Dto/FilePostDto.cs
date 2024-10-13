using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FilePostDto
    {
        public byte[] bytes { get; set; }
        public string contentType { get; set; }
        public string fileName { get; set; }
    }
}
