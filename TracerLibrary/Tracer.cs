using System;
using System.Collections.Generic;

namespace TracerLibrary
{
    public class Tracer : ITracer
    {
        private List<ThreadInfo> threads = new List<ThreadInfo> { };
        public static object locker = new object();

        public void StartTrace()
        {

        }

        public void StopTrace()
        {

        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(threads);
        }
    }
}
