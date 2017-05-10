using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Model;

namespace Dropbox.DataAccess
{
    public interface ICommentsRepository
    {
        Comment Add(Comment comment);
        Comment GetInfo(Guid commentId);
        string GetText(Guid id);
        void UpdateText(Guid commentId, string text);
        IEnumerable<Comment> GetFileComments(Guid fileId);
        void Delete(Guid id);
    }
}
