using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    internal class NotImplementedException : Exception
    {
        public NotImplementedException()
        {

        }

        public NotImplementedException(string message) : base(message)
        {

        }
    }
}
