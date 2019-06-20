using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.Models
{
    public class Author
    {
        public Guid  ID { get; set; }
        public string Name { get; set; }
        public DateTime DoB { get; set; }
    }
}
