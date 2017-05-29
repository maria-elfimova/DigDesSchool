using System;
using Dropbox.Model;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dropbox.DataAccess.Sql.Tests
{
    [TestClass]
    public class SharesRepositoryTest
    {
        private const string ConnectionString = "Data Source=JACK\\SQLEXPRESS01; Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ISharesRepository _sharesRepository;

        private User TestUser { get; set; }

        public SharesRepositoryTest()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _sharesRepository = new SharesRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        [TestInitialize]
        public void Init()
        {
            if (TestUser != null)
            {
                foreach (var file in _filesRepository.GetUserFiles(TestUser.Id))
                    _filesRepository.Delete(file.Id);
                _usersRepository.Delete(TestUser.Id);
            }
            TestUser = _usersRepository.Add("test", "test@test.com");
        }

        [TestCleanup]
        public void Clean()
        {
            if (TestUser != null)
            {
                foreach (var file in _filesRepository.GetUserFiles(TestUser.Id))
                    _filesRepository.Delete(file.Id);
                _usersRepository.Delete(TestUser.Id);
            }
        }
        [TestMethod]
        public void ShouldCreateAndGetSharing()
        {
            var file = new File
            {
                Name = "file",
                Owner = TestUser
            };
            file = _filesRepository.Add(file);
            var user = _usersRepository.Add("Jack", "email@mail.com");
            var share = new Share()
            {
                FileId = file.Id,
                UserId = user.Id
            };
            _sharesRepository.Add(user.Id, file.Id);
            foreach (var result in _sharesRepository.GetUserFiles(user.Id))
            {
                Assert.AreEqual(result.Name, file.Name);
                Assert.AreEqual(result.Owner.Name, file.Owner.Name);
            }
            _sharesRepository.Delete(file.Id);
            _usersRepository.Delete(user.Id);
        }
    }
}
