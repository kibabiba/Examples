using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeLibrary;

namespace NLogExample
{
    class Program
    {
        static void Main()
        {
            var a = new InheritClass();
            ((BaseClass)a).Method();
        }
    }

    public class BaseClass
    {
        public void Method()
        {
            Console.WriteLine("Base");
        }
    }

    public class InheritClass : BaseClass
    {
        public new void Method()
        {
            Console.WriteLine("Inherit");
        }
    }
}
