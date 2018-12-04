using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Runtime.Remoting.Contexts;

namespace Ch19_P9_ThreadPoolApp
{
    [Synchronization]
    class Printer
    {
        private static readonly object locker = new object();
        public void PrintNumbers()
        {
            Monitor.Enter(locker);
            //lock (locker)
            try
            {
                  // Display Thread info.
                  Console.WriteLine("-> {0} is executing PrintNumbers()",
                                              Thread.CurrentThread.Name);
                  // Print out numbers.
                  Console.Write("\n Your numbers:  " );
                  for (int i = 0; i < 10; i++)
                  {
                      // Put thread to sleep for a random amount of time.
                      Random r = new Random();
                      Thread.Sleep(500 * r.Next(5));
                      Console.Write("{0}, ", i);
                  }
                  Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }
    }
}
