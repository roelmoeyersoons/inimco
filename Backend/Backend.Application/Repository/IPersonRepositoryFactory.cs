using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Repository
{
    public interface IPersonRepositoryFactory
    {
        public IPersonRepository GetRepository();
    }
}
