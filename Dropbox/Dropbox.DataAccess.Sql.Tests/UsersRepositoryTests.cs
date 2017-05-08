using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dropbox.Model;
using Dropbox.DataAccess.Sql;

namespace Dropbox.DataAccess.Sql.Tests
{
    [TestClass]
    public class UsersRepositoryTests
    {
        private const string ConnectionString = "Data Source=JACK\\SQLEXPRESS01; Initial Catalog=Dropbox;Integrated Security=True;User ID=dbo";
        private readonly IUsersRepository _usersRepository;

        public UsersRepositoryTests()
        {
            _usersRepository = new UsersRepository(ConnectionString);
        }

        [TestInitialize]


        [TestCleanup]
        public void Clean()
        {

        }

        [TestMethod]
        public void ShouldAddNewUser()
        {
            //arrange
            string name = "Jack";
            string email = "12345@email.com";
            //act
            var newUser = _usersRepository.Add(name, email);
            var result = _usersRepository.Get(newUser.Id);
            //asserts
            Assert.AreEqual(newUser.Name, name);
            Assert.AreEqual(newUser.Email, email);
        }

        //[TestMethod]
        //public void TestMethod1()
        //{
        //}
    }
}
