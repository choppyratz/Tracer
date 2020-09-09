using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Serialization;

namespace TracerLibrary
{
    [Serializable]
    public class ThreadInfo
    {

        [JsonProperty("id")]
        [XmlAttribute("id")]
        public int _id;

        [JsonProperty("time")]
        [XmlAttribute("time")]
        public int millisecinds;

        [JsonIgnore]
        [XmlIgnore]
        public MethodInfo currMethod = null;

        [JsonIgnore]
        [XmlIgnore]
        public MethodInfo parent = null;

        [JsonIgnore]
        [XmlIgnore]
        public Stopwatch _tracer;


        [JsonProperty("methods")]
        [XmlElement("method")]
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
