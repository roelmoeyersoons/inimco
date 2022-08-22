using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Repository
{
    public interface IPersonRepository 
    {

        public DbSet<Person> Persons { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<ISocialAccount> SocialAccounts { get; set; }

        public Task<int> SaveChangesAsync();

    }
}
