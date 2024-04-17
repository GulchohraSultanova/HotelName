using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exseptions
{
    public class NullReferanceException : Exception
    {
        public NullReferanceException(string message):base(message) {

        }
        
    }
}
