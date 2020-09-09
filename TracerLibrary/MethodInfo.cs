using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Serialization;

namespace TracerLibrary
{
    [Serializable]
    public class MethodInfo
    {
        [JsonProperty("class")]
        [XmlAttribute("class")]
        public string _className;

        [JsonProperty("name")]
        [XmlAttribute("name")]
        public string _methodName;

        [JsonProperty("time")]
        [XmlAttribute("time")]
        public int millisecinds;

        [JsonIgnore]
        [XmlIgnore]
        public MethodInfo parent = null;

        [JsonIgnore]
        [XmlIgnore]
        public Stopwatch _tracer;

        [XmlElement("method")]
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
