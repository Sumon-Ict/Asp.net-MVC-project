using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenpendencyInjection
{
    public class Substraction : IMathFunction
    {
        public void add(int a, int b)
        {
            var r = a + b;
            Console.WriteLine($"using substraction class using result: {r}");
        }

        public void sub(int a, int b)
        {
            var r = a - b;
            Console.WriteLine($"using substraction  method using {r}");

        }
        public string Name()
        {
            return "substraction";

        }
    }
}
