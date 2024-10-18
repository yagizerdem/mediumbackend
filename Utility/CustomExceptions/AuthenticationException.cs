using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.CustomExceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException() : base()
        {
        }
        public AuthenticationException(string message) : base(message)
        {
        }
        public AuthenticationException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
