using Backend.Application.Repository;
using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Operations
{
    public class RetrievePersonParams : IOperationParameters
    {
        public Guid Id { get; set; } 
    }

    public class RetrievePerson : IAsyncOperation<RetrievePersonParams, Person>
    {
        private IPersonRepository _repo { get; set; }

        public RetrievePerson(IPersonRepositoryFactory factory)
        {
            _repo = factory.GetRepository();
        }

        public async Task<Person> ExecuteAsync(RetrievePersonParams parameters)
        {
            var foundPerson = await _repo.Persons.FindAsync(parameters.Id);

            return foundPerson;
        }
    }
}
