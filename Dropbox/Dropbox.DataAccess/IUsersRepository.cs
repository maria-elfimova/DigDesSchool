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
        //void UpdateInfo(Guid userId, User user);
        void Delete(Guid id);
        User Get(Guid id);
    }
}
