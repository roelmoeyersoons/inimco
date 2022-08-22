using Backend.Model;
using Backend.Model.SocialAccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Factories
{
    internal class SocialMediaFactoryByReflection : ISocialMediaFactory
    {
        //Uses reflection which is not ideal ;)
        //alternative: store static enum value per social media type, however statics cannot be defined in interfaces / don't get inherited
        //so here you are also running into problems

        private static readonly Dictionary<string, Type> _socialMediaMappings = new Dictionary<string, Type>
        {
            { "twitter" , typeof(Twitter) }
        };

        public ISocialAccount InstantiateSocialAccount(string socialMediaAccountType)
        {
            if (socialMediaAccountType is null)
                throw new ArgumentNullException();

            var cleanedTypeName = socialMediaAccountType.ToLower().Trim();
            if (!_socialMediaMappings.TryGetValue(cleanedTypeName, out Type typeToInstantiate))
            {
                throw new ArgumentException();
            }

            return Activator.CreateInstance(typeToInstantiate) as ISocialAccount;

        }
    }
}
