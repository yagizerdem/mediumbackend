using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.CustomExceptions
{
    public class LikeExceptions : Exception
    {
        public LikeExceptions() : base()
        {
        }
        public LikeExceptions(string message) : base(message)
        {
        }
        public LikeExceptions(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
