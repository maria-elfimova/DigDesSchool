using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dropbox.DataAccess;
using Dropbox.DataAccess.Sql;
using Dropbox.Model;

namespace Dropbox.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private const string ConnectionString = "Data Source=JACK\\SQLEXPRESS01; Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ISharesRepository _sharesRepository;

        public UsersController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _sharesRepository = new SharesRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        [Route("api/users/")]
        [HttpPost]
        public User CreateUser([FromBody]User user)
        {
            return _usersRepository.Add(user.Name, user.Email);
        }

        [HttpGet]
        public User GetUser(Guid id)
        {
            return _usersRepository.Get(id);
        }

        [HttpDelete]
        public void DeleteUser(Guid id)
        {
            _usersRepository.Delete(id);
        }

        [Route("api/users/{id}/files")]
        [HttpGet]
        public IEnumerable<File> GetUserFiles(Guid id)
        {
            return _filesRepository.GetUserFiles(id);
        }

        [Route("api/users/{id}/files")]
        [HttpGet]
        public IEnumerable<File> GetUserSharesFiles(Guid id)
        {
            return _sharesRepository.GetUserFiles(id);
        }

        [HttpPut]
        [Route("api/users/{id}")]
        public User UpdateUser(Guid id, [FromBody] User user)
        {
            return null;
        }
    }
}
