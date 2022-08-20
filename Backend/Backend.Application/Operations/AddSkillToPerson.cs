using Backend.Application.Repository;
using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Operations
{
    public class AddSkillParams : IOperationParameters
    {
        public string SkillName { get; set; }

        public Guid PersonId { get; set; }
    }


    //ideally don't retrieve a bool, but a wrapper class/struct

    public class AddSkillToPerson : IAsyncOperation<AddSkillParams, bool>
    {
        private IPersonRepository _repo { get; set; }

        public AddSkillToPerson(IPersonRepositoryFactory<IPersonRepository> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _repo = factory.GetRepository();
        }

        public async Task<bool> ExecuteAsync(AddSkillParams parameters)
        {
            // put validation logic here, check for fields + if person already exists ect

            //

            var person = await _repo.Persons.FindAsync(parameters.PersonId);

            if (person == null)
            {
                throw new Exception();
            }

            var foundDbSkill = await _repo.Skills.FindAsync(parameters.SkillName);
            if (foundDbSkill == null)
            {
                foundDbSkill = new Skill { Name = parameters.SkillName };
                await _repo.Skills.AddAsync(foundDbSkill);
            }

            foundDbSkill.Persons.Add(person);

            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
