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
        [Route("api/comments")]
        public Comment CreateComment(Comment comment)
        {
            comment = _commentsRepository.Add(comment);
            Log.Logger.ServiceLog.Info("Создан комментарий с id: {0}", comment.Id);
            return comment;
        }

        [HttpGet]
        [Route("api/comments/{id}")]
        public Comment GetComment(Guid id)
        {
            return _commentsRepository.GetInfo(id);
        }

        [HttpPut]
        [Route("api/comments/{id}/text")]
        public async Task UpdateComment(Guid id)
        {
            Log.Logger.ServiceLog.Info("Обновлен комментарий с id: {0}", id);
            var text = await Request.Content.ReadAsStringAsync();
            _commentsRepository.UpdateText(id, text);
        }

        [HttpDelete]
        [Route("api/comments/{id}")]
        public void DeleteComment(Guid id)
        {
            Log.Logger.ServiceLog.Warn("Удален комментарий с id: {0}", id);
            _commentsRepository.Delete(id);
        }
    }
}