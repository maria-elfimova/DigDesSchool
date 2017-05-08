using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Model;

namespace Dropbox.DataAccess
{
    public interface IFilesRepository
    {
        File Add(File file);
        byte[] GetContent(Guid id);
        File GetInfo(Guid fileId);
        void UpdateContent(Guid fileId, byte[] content);
        IEnumerable<File> GetUserFiles(Guid id);
        void Delete(Guid id);
    }
}
