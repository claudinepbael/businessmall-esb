using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Businessmall.Exceptions
{
    public class InvalidLoginCredentialsException :Exception
    {
        public InvalidLoginCredentialsException(string message)
            :base(message)
        { 

        }

        public InvalidLoginCredentialsException(string message, Exception inner)
            :base(message)
        { 
        
        }
    }
}