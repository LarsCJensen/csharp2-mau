using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class FileClass
    {
        // File, Icon, Name, Path, DateCreated, DateModified
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? Extension { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string? Size { get; set; }
        public long CheckSum { get; set; }
        public bool Selected { get; set; }
    }
}
