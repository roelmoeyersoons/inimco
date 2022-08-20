using Backend.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Persistence
{
    internal class IninmcoDbContextFactory : IPersonRepositoryFactory<InimcoDbContext>
    {
        public InimcoDbContext GetRepository()
        {
            return new InimcoDbContext();
        }
    }
}
