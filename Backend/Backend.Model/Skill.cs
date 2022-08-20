using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Skill
    {
        public string Name { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
