using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenpendencyInjection
{
    public class Addittion : IMathFunction
    {
        public void add(int a, int b)
        {
            var r = a + b;
            Console.WriteLine(r);

        }

        public void sub(int a, int b)
        {
            Console.WriteLine(a - b);

        }

        public string methodName()
        {
            return "Addition";

        }
    }
}
