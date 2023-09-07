using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace FileParser
{
    /// <summary>
    /// FileParser that parse xml files
    /// </summary>
    public class XMLFileParser : IFIleParser
    {        
        public T ParseFile<T>(T Output, string filePath)
        {            
            XmlSerializer xs = new XmlSerializer(typeof(T));
            FileStream reader = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            T Config = (T)xs.Deserialize(reader);
            reader.Close();
            return Config;
        }                
    }
}
