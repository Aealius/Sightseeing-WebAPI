﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    internal class KeyNotFoundException : Exception
    {
        public KeyNotFoundException()
        {

        }

        public KeyNotFoundException(string message) : base(message)
        {

        }
    }
}
