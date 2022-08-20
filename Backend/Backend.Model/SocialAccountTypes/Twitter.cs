using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model.SocialAccountTypes
{
    public class Twitter : ISocialAccount
    {
        public string Address { get; set; }

        public string ConstructUrl()
        {
            throw new NotImplementedException();
        }
    }
}
