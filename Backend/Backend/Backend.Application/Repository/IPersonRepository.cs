using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Repository
{
    public interface IPersonRepository
    {
        public Task<bool> CreatePerson(Person person);
        public Task<Person> GetPerson(string personId);
        public Task<bool> GetPeopleHavingSkills(Skill skill);

    }
}
