using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dropbox.WinForms
{
    internal class ServiceException : Exception
    {
        public ServiceException(string message, params object[] args) : base(string.Format(message, args))
        {

        }
    }
}