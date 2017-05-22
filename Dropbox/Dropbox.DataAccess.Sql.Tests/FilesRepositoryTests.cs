using System;
using System.Linq;
using System.Text;
using Dropbox.Model;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dropbox.DataAccess.Sql.Tests
{
    [TestClass]
    public class FilesRepositoryTests
    {
        private const string ConnectionString = "Data Source=JACK\\SQLEXPRESS01; Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;

        private User TestUser { get; set; }

        public FilesRepositoryTests()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
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
        public void ShouldCreateAndGetFile()
        {
            //arrange
            var file = new File
            {
                Name = "file",
                Owner = TestUser
            };
            //act
            var newFile = _filesRepository.Add(file);
            var result = _filesRepository.GetInfo(newFile.Id);
            //asserts
            Assert.AreEqual(file.Owner.Id, result.Owner.Id);
            Assert.AreEqual(file.Name, result.Name);
            _filesRepository.Delete(file.Id);
        }

        [TestMethod]
        public void ShoulUpdateFileContent()
        {
            //arrange
            var file = new File
            {
                Name = "file with content",
                Owner = TestUser
            };
            var content = Encoding.UTF8.GetBytes("Hello");
            var newFile = _filesRepository.Add(file);
            //act
            _filesRepository.UpdateContent(newFile.Id, content);
            var resultContent = _filesRepository.GetContent(newFile.Id);
            //asserts
            Assert.IsTrue(content.SequenceEqual(resultContent));
        }

        [TestMethod]
        public void ShoulGetUserFiles()
        {
            //arrange
            var file1 = new File
            {
                Name = "file1",
                Owner = TestUser
            };
            var file2 = new File
            {
                Name = "file2",
                Owner = TestUser
            };
            //act
            var newFile1 = _filesRepository.Add(file1);
            var newFile2 = _filesRepository.Add(file2);
            IEnumerable<File> userFiles = _filesRepository.GetUserFiles(TestUser.Id);
            //asserts
            Assert.AreEqual(userFiles.Count(), 2);
        }
    }
}