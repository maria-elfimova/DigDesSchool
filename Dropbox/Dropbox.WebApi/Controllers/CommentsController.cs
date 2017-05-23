using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http;
using Dropbox.DataAccess;
using Dropbox.DataAccess.Sql;
using Dropbox.Model;

namespace Dropbox.WebApi.Controllers
{
    public class CommentsController : ApiController
    {
        private const string ConnectionString = "Data Source=JACK\\SQLEXPRESS01; Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ICommentsRepository _commentsRepository;

        public CommentsController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _commentsRepository = new CommentsRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        [HttpPost]
        public Comment CreateComment(Comment comment)
        {
            return _commentsRepository.Add(comment);
        }

        [HttpGet]
        public Comment GetComment(Guid id)
        {
            return _commentsRepository.GetInfo(id);
        }

        [HttpPut]
        [Route("api/comments/{id}/text")]
        public async Task UpdateComment(Guid id)
        {
            var text = await Request.Content.ReadAsStringAsync();
            _commentsRepository.UpdateText(id, text);
        }

        [HttpDelete]
        public void DeleteComment(Guid id)
        {
            _commentsRepository.Delete(id);
        }
    }
}