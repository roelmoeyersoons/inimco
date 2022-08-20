using Backend.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Persistence
{
    public class InimcoDbContextFactory : IPersonRepositoryFactory
    {
        public IPersonRepository GetRepository()
        {

            //ideally also resolved via DI, no "new's" anywhere :)
            return new InimcoDbContext();
        }
    }
}
