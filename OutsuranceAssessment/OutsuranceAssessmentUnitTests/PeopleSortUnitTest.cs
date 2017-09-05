using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutsuranceAssessment;
using System.Collections.Generic;

namespace OutsuranceAssessmentUnitTests
{
    [TestClass]
    public class PeopleSortUnitTest
    {
        [TestMethod]
        public void SortPeopleTest()
        {
            PeopleService peopleService = new PeopleService();
            var people = new List<IPerson>();
            people.Add(new Person()
            {
                Address = "16 People Place",
                Firstname = "John",
                Lastname = "Doe",
                PhoneNumber = "0123456789"
            });
            people.Add(new Person()
            {
                Address = "106 Italy Street",
                Firstname = "Jane",
                Lastname = "Doe",
                PhoneNumber = "0123456789"
            });

            var expected = new Dictionary<string, int>();
            expected.Add("Doe", 2);
            expected.Add("Jane", 1);
            expected.Add("John", 1);

            var result = peopleService.GetOccurences(people);
            Assert.IsNotNull(result);
            Assert.AreEqual(expected["Doe"], result["Doe"]);
        }

        [TestMethod]
        public void SortAddresses()
        {
            PeopleService peopleService = new PeopleService();
            var people = new List<IPerson>();
            people.Add(new Person()
            {
                Address = "16 People Place",
                Firstname = "John",
                Lastname = "Doe",
                PhoneNumber = "0123456789"
            });
            people.Add(new Person()
            {
                Address = "106 Italy Street",
                Firstname = "Jane",
                Lastname = "Doe",
                PhoneNumber = "0123456789"
            });

            var expected = new List<IPerson>();
            expected.Add(new Person()
            {
                Address = "106 Italy Street",
                Firstname = "Jane",
                Lastname = "Doe",
                PhoneNumber = "0123456789"
            });

            var addresses = peopleService.GetSortedAddresses(people);

            Assert.IsNotNull(addresses);
            Assert.AreEqual(expected[0].Address, addresses[0]);
        }
    }
}
