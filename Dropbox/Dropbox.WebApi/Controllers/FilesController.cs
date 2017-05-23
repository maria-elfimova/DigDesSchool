using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Dropbox.Model;
using Dropbox.DataAccess;
using Dropbox.DataAccess.Sql;
using File = Dropbox.Model.File;

namespace Dropbox.WebApi.Controllers
{
    public class FilesController : ApiController
    {
        private const string ConnectionString = "Data Source=JACK\\SQLEXPRESS01; Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ICommentsRepository _commentsRepository;

        public FilesController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _commentsRepository = new CommentsRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        [HttpPost]
        public File CreateFile(File file)
        {
            return _filesRepository.Add(file);
        }

        [HttpGet]
        public byte[] GetFileContent(Guid id)
        {
            return _filesRepository.GetContent(id);
        }

        [HttpGet]
        public File GetFile(Guid id)
        {
            return _filesRepository.GetInfo(id);
        }

        [HttpPut]
        [Route("api/files/{id}/content")]
        public async Task UpdateFileContent(Guid id)
        {
            var bytes = await Request.Content.ReadAsByteArrayAsync();
            _filesRepository.UpdateContent(id, bytes);
        }

        [Route("api/files/{id}/comments")]
        [HttpGet]
        public IEnumerable<Comment> GetFileComments(Guid id)
        {
            return _commentsRepository.GetFileComments(id);
        }

        [HttpDelete]
        public void DeleteFile(Guid id)
        {
            _filesRepository.Delete(id);
        }
    }
}
