using System;
using System.Collections.Generic;
using System.Text;
using ExtendedXmlSerializer;
using ExtendedXmlSerializer.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace TracerLibrary
{
    class XMLSerialize : ISerialize
    {
        public Type serializeType;
        public XMLSerialize(Type type)
        {
            serializeType = type;
        }

        public string getResult(object obj)
        {
            string xmlStr = String.Empty;
            XmlSerializer formatter = new XmlSerializer(serializeType);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    XmlSerializer serializer = new XmlSerializer(serializeType);
                    serializer.Serialize(xmlWriter, obj);
                    xmlStr = stringWriter.ToString();
                    xmlWriter.Close();
                }
            }
            return xmlStr;
        }
    }
}
