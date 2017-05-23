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
    public class SharesController : ApiController
    {
        private const string ConnectionString = "Data Source=JACK\\SQLEXPRESS01; Initial Catalog=Dropbox;Integrated Security=True";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ISharesRepository _sharesRepository;

        public SharesController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _sharesRepository = new SharesRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        [HttpPost]
        public void CreateShare(Share share)
        {
            _sharesRepository.Add(share);
        }

        [HttpDelete]
        public void DeleteShare(Share share)
        {
            _sharesRepository.Delete(share);
        }
    }
}
