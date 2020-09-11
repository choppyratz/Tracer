using System;
using System.Collections.Generic;
using System.Text;

namespace Tracer
{
    class ConsoleOutput : IOutPut
    {
        public void printResult(string content)
        {
            Console.WriteLine(content);
        }
    }
}
