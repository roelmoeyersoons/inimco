using Backend.Application.Repository;
using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Operations
{
    public class AddPersonParams : IOperationParameters
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    //ideally don't retrieve a guid, but a wrapper class


    public class AddPerson : IAsyncOperation<AddPersonParams, Guid>
    {
        private IPersonRepository _repo { get; set; }


        public AddPerson(IPersonRepositoryFactory<IPersonRepository> factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _repo = factory.GetRepository();
        }

        public async Task<Guid> ExecuteAsync(AddPersonParams parameters)
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

            return newPerson.Id;
        }
    }
}
