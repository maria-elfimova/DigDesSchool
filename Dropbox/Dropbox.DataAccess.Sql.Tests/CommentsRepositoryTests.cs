using System;
using Dropbox.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dropbox.DataAccess.Sql.Tests
{
    [TestClass]
    public class CommentsRepositoryTests
    {
        private const string ConnectionString = "Data Source=JACK\\SQLEXPRESS01; Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ICommentsRepository _commentsRepository;

        private User TestUser { get; set; }
        private File TestFile { get; set; }

        public CommentsRepositoryTests()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _commentsRepository = new CommentsRepository(ConnectionString, _usersRepository, _filesRepository);
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
            TestFile = new File
            {
                Name = "file",
                Owner = TestUser
            };
            var newFile = _filesRepository.Add(TestFile);
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
        public void ShouldCreateAndGetComment()
        {
            //arrange
            var comment = new Comment
            {
                FileId = TestFile.Id,
                UserId = TestUser.Id,
                Text = "comment's text"
            };
            //act
            var newComment = _commentsRepository.Add(comment);
            var result = _commentsRepository.GetInfo(newComment.Id);
            //asserts
            Assert.AreEqual(newComment.Id, result.Id);
            Assert.AreEqual(newComment.FileId, result.FileId);
            Assert.AreEqual(newComment.UserId, result.UserId);
            Assert.AreEqual(newComment.Text, result.Text);
            _commentsRepository.Delete(newComment.Id);
        }

        [TestMethod]
        public void ShouldUpdateComment()
        {
            //arrange
            var comment = new Comment
            {
                FileId = TestFile.Id,
                UserId = TestUser.Id,
                Text = "comment's text"
            };
            //act
            var newComment = _commentsRepository.Add(comment);
            _commentsRepository.UpdateText(newComment.Id, "this is new text");
            var result = _commentsRepository.GetInfo(newComment.Id);
            //asserts
            Assert.AreEqual(newComment.Id, result.Id);
            Assert.AreEqual(newComment.FileId, result.FileId);
            Assert.AreEqual(newComment.UserId, result.UserId);
            Assert.AreEqual("this is new text", result.Text);
            _commentsRepository.Delete(newComment.Id);
        }

        [TestMethod]
        public void ShouldGetFileComment()
        {
            //arrange
            var comment = new Comment
            {
                FileId = TestFile.Id,
                UserId = TestUser.Id,
                Text = "comment's text"
            };
            //act
            var newComment = _commentsRepository.Add(comment);
            //asserts
            foreach (var result in _commentsRepository.GetFileComments(TestFile.Id))
            {
                Assert.AreEqual(newComment.Id, result.Id);
                Assert.AreEqual(newComment.FileId, result.FileId);
                Assert.AreEqual(newComment.UserId, result.UserId);
                Assert.AreEqual(newComment.Text, result.Text);
            }
            _commentsRepository.Delete(newComment.Id);
        }
    }
}
