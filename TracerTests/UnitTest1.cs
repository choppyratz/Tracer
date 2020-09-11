using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using TracerLibrary;
using System.Diagnostics;

namespace TracerTests
{
    [TestClass]
    public class UnitTest1
    {
        private TraceResult result;

        [TestInitialize]
        public void SetupContext()
        {
            TracerLibrary.Tracer tracer = new TracerLibrary.Tracer();
            new Foo(tracer).MyMethod();
            Thread thrd1 = new Thread(new ThreadStart(new Bar(tracer).InnerMethod));
            thrd1.Start();
            thrd1.Join();
            result = tracer.GetTraceResult();
        }

        [TestMethod]
        public void TestThreadCount()
        {
            Assert.AreEqual(2, result._threads.Count);
        }

        [TestMethod]
        public void TestMethodNesting()
        {
            Assert.AreEqual(2, result._threads[1].stackContext[0].methods.Count);
        }

        [TestMethod]
        public void TestName()
        {
            Assert.AreEqual("InnerMethod", result._threads[1].stackContext[0]._methodName);
            Assert.AreEqual("Bar", result._threads[1].stackContext[0]._className);
        }

        [TestMethod]
        public void TestExecTime()
        {
            Stopwatch testTracer = new Stopwatch();
            testTracer.Start();
            Thread.Sleep(2000);
            TracerLibrary.Tracer tracer = new TracerLibrary.Tracer();
            new Foo(tracer).Test();
            result = tracer.GetTraceResult();
            testTracer.Stop();
            Assert.IsTrue(testTracer.ElapsedMilliseconds >= result._threads[0].millisecinds);
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

        public void Test()
        {
            _tracer.StartTrace();
            Thread.Sleep(2000);
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
