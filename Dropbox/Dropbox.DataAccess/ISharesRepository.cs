using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Model;

namespace Dropbox.DataAccess
{
    public interface ISharesRepository
    {
        void Add(Share share);
        void Delete(Guid fileId);
        IEnumerable<File> GetUserFiles(Guid userId);
    }
}
