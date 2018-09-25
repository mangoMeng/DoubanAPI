using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ClassA : ITest
    {
        public string Sayhello()
        {
            return "Hello World";
        }
    }
}
