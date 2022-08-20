using Backend.Application.Factories;
using Backend.Application.Repository;
using Backend.Model;
using Backend.Model.SocialAccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Operations
{

    public class AddPersonOldParams : IOperationParameters
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<string> Skills { get; set; }

        public IEnumerable<PersonSocialMediaParams> SocialMedia { get; set; }
    }

    public class PersonSocialMediaParams
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    /* This operation could have been split up into multiple tinier operations
        - Addperson only saves a person
        - AddSocialMedia adds social media account to existing person
        - AddSkill adds skill to existing person 
        
        The API layer then connects these operations

        This is probably the better approach for testability and SOLID principles 

        This bothered me so i renamed this class to AddPersonOld and created the new classes
    */


    //ideally don't retrieve a guid, but a wrapper class/struct

    public class AddPersonOld : IAsyncOperation<AddPersonOldParams, Guid>
    {
        private IPersonRepository _repo { get; set; }
        private ISocialMediaFactory _socialMediaFactory { get; }

        public AddPersonOld(IPersonRepositoryFactory factory, ISocialMediaFactory socialMediaFactory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _repo = factory.GetRepository();
            _socialMediaFactory = socialMediaFactory ?? throw new ArgumentNullException(nameof(socialMediaFactory));
        }

        public async Task<Guid> ExecuteAsync(AddPersonOldParams parameters)
        {
            // put validation logic here, check for fields + if person already exists ect

            //

            var newPerson = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = parameters.FirstName,
                LastName = parameters.LastName, 
            };

            await _repo.Persons.AddAsync(newPerson);

            var taskList = new List<Task>();
            foreach(var skill in parameters.Skills ?? Enumerable.Empty<string>())
            {
                taskList.Add(LinkPersonToSkill(skill, newPerson));
            }

            foreach (var socialAccount in parameters.SocialMedia ?? Enumerable.Empty<PersonSocialMediaParams>())
            {
                var newSocialMedia = _socialMediaFactory.InstantiateSocialAccount(socialAccount.Name);
                newSocialMedia.Address = socialAccount.Address;
                newSocialMedia.Person = newPerson;

                taskList.Add(_repo.SocialAccounts.AddAsync(newSocialMedia).AsTask());
            }

            await Task.WhenAll(taskList);

            await _repo.SaveChangesAsync();


            return newPerson.Id;
        }

        private async Task LinkPersonToSkill(string skillName, Person person)
        {
            var skill = await GetOrAddSkill(skillName);
            skill.Persons.Add(person);
        }

        private async Task<Skill> GetOrAddSkill(string skillName)
        {
            //to configure: skillname should be the key or whaterver so that Find can find it
            var foundDbSkill = await _repo.Skills.FindAsync(skillName);

            if (foundDbSkill == null)
            {
                foundDbSkill = new Skill { Name = skillName };
                await _repo.Skills.AddAsync(foundDbSkill);
            }

            return foundDbSkill;
        }

        
    }
}
