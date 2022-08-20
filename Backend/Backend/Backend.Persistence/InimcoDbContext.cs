using Backend.Application.Repository;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence
{
    public class InimcoDbContext : DbContext, IPersonRepository
    {

        
        public Task<bool> CreatePerson(Person person)
        {
            Add(person);
            return Task.FromResult(true);
        }

        public Task<bool> GetPeopleHavingSkills(Skill skill)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetPerson(string personId)
        {
            retrun
        }
    }
}