using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class Test
    {

        ~Test()
        {
            // Destructor logic here
            Console.WriteLine("Finalizer called for Test class.");
        }
        public static void Run()
        {
            Test test = new Test();
            // Do something with the test object
            Console.WriteLine("Test object created.");
            // Force garbage collection to demonstrate the finalizer
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("End of Run method.");

        }





    }
    class Resource : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }

        
    }

    
}
