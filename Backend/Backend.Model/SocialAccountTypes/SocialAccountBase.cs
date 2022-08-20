using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model.SocialAccountTypes
{
    public abstract class SocialAccountBase : ISocialAccount
    {
        public string Address { get; set; }

        public Person Person { get; set; }

        public virtual string ConstructUrl()
        {
            throw new NotImplementedException();
        }
    }
}
