using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Model;

namespace Dropbox.DataAccess
{
    public interface IUsersRepository
    {
        User Add(string name, string email);
        void Delete(Guid id);
        User Get(Guid id);
        User GetByMail(string email);
    }
}
