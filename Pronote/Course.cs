using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronote
{
    public class Course
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
