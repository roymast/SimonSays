using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace FileParser
{
    /// <summary>
    /// FileParser that parse json files
    /// </summary>
    public class JsonFileParser : IFIleParser
    {                     
        public override T ParseFile<T>(T Output)
        {
            T Config;
            using (StreamReader r = new StreamReader(_filePath))
            {
                string json = r.ReadToEnd();                
                Config = JsonConvert.DeserializeObject<T>(json);
            }
            return Config;
        }
    }
}