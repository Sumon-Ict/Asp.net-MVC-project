using System;

namespace DenpendencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {

            var inectob = new Injection(new Addittion());   //dependency injection

            inectob._mathFunction.add(12, 34);
            inectob._mathFunction.sub(34, 56);

            var ob2 = new Injection(new Substraction());

            ob2._mathFunction.add(89, 90);

            ob2._mathFunction.sub(123, 90);


            var ob3 = new Addittion();
               var r1=ob3.methodName();
            Console.WriteLine(r1);


            var ob4 = new Substraction();
            var r2 = ob4.Name();
            Console.WriteLine(r2);





           
        }
    }
}
