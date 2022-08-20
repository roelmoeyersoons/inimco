using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Application.Extensions.Tests
{
    public class PersonExtensionsTests
    {

        [TestMethod()]
        [DataRow("John", "Doe", "eoD nhoJ")]
        [DataRow("Roel", "", "leoR")]
        public void ReverseName_reverses_name(string firstName, string lastName, string validResult)
        {
            var person = new Person
            {
                FirstName = firstName,
                LastName = lastName
            };

            var result = person.ReverseName();

            Assert.AreEqual(validResult, result);
        }

        [TestMethod()]
        public void ReverseName_should_reverse_if_only_lastname()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReverseName_should_reverse_if_only_firstname()
        {
            Assert.Fail();
        }
    }
}