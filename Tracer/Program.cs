using System;
using System.Threading;
using TracerLibrary;

namespace Tracer
{
    class Program
    {
        static void Main(string[] args)
        {
            TracerLibrary.Tracer tracer = new TracerLibrary.Tracer();
            Thread thrd1 = new Thread(new ThreadStart(new Bar(tracer).InnerMethod));
            new Foo(tracer).MyMethod();
            thrd1.Start();
            thrd1.Join();
            TraceResult result = tracer.GetTraceResult();
            new FileOutput().printResult(result.getXMLResult());
            new ConsoleOutput().printResult(result.getXMLResult());
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
