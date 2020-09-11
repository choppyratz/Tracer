using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tracer
{
    class FileOutput : IOutPut
    {
        public void printResult(string content)
        {
            File.WriteAllText("test.txt", content);
        }
    }
}
