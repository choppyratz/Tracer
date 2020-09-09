using System;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using TracerLibrary;

namespace Tracer
{
    class Program
    {
        static void Main(string[] args)
        {
            TracerLibrary.Tracer tracer = new TracerLibrary.Tracer();
 
            new Foo(tracer).MyMethod();
            Thread thrd1 = new Thread(new ThreadStart(new Bar(tracer).InnerMethod));
            thrd1.Start();
            //new Foo(tracer).Test();
            Thread.Sleep(10000);
            TraceResult result = tracer.GetTraceResult();
            Console.WriteLine(result.getJSONResult());
            Console.ReadKey();
        }
    }

    public class Foo
    {
        private Bar _bar;
        private ITracer _tracer;

        internal Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            _bar.InnerMethod();
            Thread.Sleep(1000);
            _tracer.StopTrace();
        }
    }

    public class Bar
    {
        private ITracer _tracer;

        internal Bar(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
            InnerMethod2();
            Thread.Sleep(1000);
            _tracer.StopTrace();
        }

        public void InnerMethod2()
        {
            _tracer.StartTrace();
            Thread.Sleep(1000);
            _tracer.StopTrace();
        }
    }
}
