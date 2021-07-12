using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenpendencyInjection
{
 public    class Injection
    {
        public IMathFunction _mathFunction;

        public Injection(IMathFunction mathFunction)
        {
            _mathFunction = mathFunction;

        }

       
    }
}
