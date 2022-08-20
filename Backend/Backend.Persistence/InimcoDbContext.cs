using Backend.Application.Repository;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence
{
    public class InimcoDbContext : DbContext, IPersonRepository
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<ISocialAccount> SocialAccounts { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}