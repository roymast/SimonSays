using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Configurations
{
    public class JsonFileReader : IFIleReader
    {                     
        public override void ReadConfig<T>(ref T Config)
        {
            using (StreamReader r = new StreamReader(_filePath))
            {
                string json = r.ReadToEnd();
                Config = JsonUtility.FromJson<T>(json);
            }
        }
    }
}