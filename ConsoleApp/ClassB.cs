using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ClassB
    {
        public static void Main()
        {
            ITest test = new ClassA();
            Console.WriteLine(test.GetType());
            Console.WriteLine(test.Sayhello());
            Console.Read();
        }

    }
}
