using Backend.Application.Factories;
using Backend.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Operations
{
    public class AddSocialMediaParams : IOperationParameters
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }


    //ideally don't retrieve a bool, but a wrapper class/struct

    public class AddSocialMediaToPerson : IAsyncOperation<AddSocialMediaParams, bool>
    {
        private IPersonRepository _repo { get; set; }

        private ISocialMediaFactory _socialMediaFactory;

        public AddSocialMediaToPerson(IPersonRepositoryFactory<IPersonRepository> factory, ISocialMediaFactory socialMediaFactory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _repo = factory.GetRepository();
            _socialMediaFactory = socialMediaFactory ?? throw new ArgumentNullException(nameof(socialMediaFactory));
        }

        public async Task<bool> ExecuteAsync(AddSocialMediaParams parameters)
        {
            // put validation logic here, check for fields + if person already exists ect

            //

            var person = await _repo.Persons.FindAsync(parameters.PersonId);

            if (person == null)
            {
                throw new Exception();
            }

            var newSocialMedia = _socialMediaFactory.InstantiateSocialAccount(parameters.Name);
            newSocialMedia.Address = parameters.Address;
            newSocialMedia.Person = person;

            await _repo.SocialAccounts.AddAsync(newSocialMedia);

            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
