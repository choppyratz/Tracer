using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TracerLibrary
{
    public class TraceResult
    {
        [JsonProperty("threads")]
        public List<ThreadInfo> _threads = new List<ThreadInfo> { };

        public string json = "";
        public string xml = "";

        public TraceResult(List<ThreadInfo> threads)
        {
            _threads = threads;
            json = new JSONSerialize().getResult(_threads);
        }

        public string getJSONResult()
        {
            return json;
        }

        public string getXMLResult()
        {
            return xml;
        }
    }
}
