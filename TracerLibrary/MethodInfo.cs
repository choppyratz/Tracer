using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TracerLibrary
{
    [Serializable]
    public class MethodInfo
    {
        [JsonProperty("class")]
        public string _className;

        [JsonProperty("name")]
        public string _methodName;

        [JsonProperty("time")]
        public int millisecinds;

        [JsonIgnore]
        public MethodInfo parent = null;

        [JsonIgnore]
        public Stopwatch _tracer;

        public List<MethodInfo> methods;

        public MethodInfo(string className, string methodName, Stopwatch tracer)
        {
            methods = new List<MethodInfo> { };
            _className = className;
            _methodName = methodName;
            _tracer = tracer;
        }

        public MethodInfo()
        {

        }
    }
}
