using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Configurations
{
    public class XMLFileReader : IFIleReader
    {        
        public override void ReadConfig<T>(ref T Config)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            FileStream reader = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            Config = (T)xs.Deserialize(reader);
            reader.Close();
        }                
    }
}
