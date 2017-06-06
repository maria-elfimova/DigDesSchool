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
        private readonly ISharesRepository _sharesRepository;

        public FilesController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _commentsRepository = new CommentsRepository(ConnectionString, _usersRepository, _filesRepository);
            _sharesRepository = new SharesRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        [HttpPost]
        [Route("api/files/")]
        public File CreateFile(File file)
        {
            file = _filesRepository.Add(file);
            Log.Logger.ServiceLog.Info("Создан файл с id: {0}", file.Id);
            return file;
        }

        [HttpGet]
        [Route("api/files/{id}/content")]
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
            Log.Logger.ServiceLog.Info("Изменено содержание файла с id: {0}", id);

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
            Log.Logger.ServiceLog.Warn("Удален файл с id: {0}", id);
            _filesRepository.Delete(id);
        }

        [HttpPost]
        [Route("api/files/SharingFiles")]
        public void CreateShare([FromBody]Share share)
        {
            Log.Logger.ServiceLog.Info("Разрешен доступ для файла с id: {0} для пользователя с id: {0}", share.FileId, share.UserId);
            _sharesRepository.Add(share);
        }

        [HttpDelete]
        [Route("api/files/{id}/SharingFiles")]
        public void DeleteShare(Guid fileId)
        {
            Log.Logger.ServiceLog.Warn("Удален общий доступ к файлу с id: {0}", fileId);
            _sharesRepository.Delete(fileId);
        }
    }
}
