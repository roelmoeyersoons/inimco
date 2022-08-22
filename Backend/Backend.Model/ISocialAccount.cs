using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model
{
    public interface ISocialAccount
    {
        public string Address { get; set; }

        public string ConstructUrl();

        public Person Person { get; set; }
    }
}
