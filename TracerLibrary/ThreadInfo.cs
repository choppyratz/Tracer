using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TracerLibrary
{
    [Serializable]
    public class ThreadInfo
    {

        [JsonProperty("id")]
        public int _id;

        [JsonProperty("time")]
        public int millisecinds;

        [JsonIgnore]
        public MethodInfo currMethod = null;

        [JsonIgnore]
        public MethodInfo parent = null;

        [JsonIgnore]
        public Stopwatch _tracer;


        [JsonProperty("methods")]
        public List<MethodInfo> stackContext = new List<MethodInfo> { };

        public ThreadInfo(int id, Stopwatch tracer)
        {
            _id = id;
            _tracer = tracer;
        }

        public ThreadInfo()
        {

        }
    }
}
