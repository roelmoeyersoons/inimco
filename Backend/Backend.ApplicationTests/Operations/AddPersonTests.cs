using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Application.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Backend.Application.Repository;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using Backend.Application.Factories;
using Bogus;

namespace Backend.Application.Operations.Tests
{
    [TestClass()]
    public class AddPersonTests
    {

        public class myTestDbFactory : IPersonRepositoryFactory
        {
            public Mock<IPersonRepository> Mock { get; set; }

            public IPersonRepository GetRepository()
            {
                return Mock.Object;
            }
        }

        [TestMethod()]
        public async Task ExecuteAsyncTest()
        {
            var dbContextMock = new Mock<IPersonRepository>();
            var dbSetMock = new Mock<DbSet<Model.Person>>();

            var mockedFactory = new myTestDbFactory
            {
                Mock = dbContextMock
            };

            var faker = new Faker();

            // further initialize mock for test case

            var addPersonOperation = new AddPerson(mockedFactory);

            var addpersonParams = new AddPersonParams
            {
                FirstName = faker.Random.Word(),
                LastName = faker.Random.Word(),
            };

            await addPersonOperation.ExecuteAsync(addpersonParams);
            
            //do your asserts here, compare input params with what's passed to the mock

            Assert.IsTrue(true);
        }
    }
}