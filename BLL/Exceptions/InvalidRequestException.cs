using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    internal class InvalidRequestException : Exception
    {
        public InvalidRequestException()
        {

        }

        public InvalidRequestException(string message) : base(message)
        {

        }
    }
}
