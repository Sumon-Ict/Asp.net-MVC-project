using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Training.Exceptions
{
  public class InvalidParameterException : Exception
    {

        public  InvalidParameterException(string message)
            : base(message)
        {

        }
    }
}
