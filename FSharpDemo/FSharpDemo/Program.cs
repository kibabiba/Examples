using System;
using System.Collections.Generic;
using FSharpLibrary;

namespace FSharpDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(MyMathLib.sumOfSquares(4));

            var testUser = new MyMathLib.TestUser("Test", 19);
            MyMathLib.PrintUsers(new List<MyMathLib.TestUser> { testUser, testUser, testUser});

            Console.ReadKey();
        }
    }
}
