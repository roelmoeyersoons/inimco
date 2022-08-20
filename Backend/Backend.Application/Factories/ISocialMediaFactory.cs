using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Factories
{
    public interface ISocialMediaFactory
    {
        ISocialAccount InstantiateSocialAccount(string socialMediaAccountType);
    }
}
