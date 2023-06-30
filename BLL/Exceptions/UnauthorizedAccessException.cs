using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    internal class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException()
        {

        }

        public UnauthorizedAccessException(string message) : base(message)
        {

        }
    }
}
