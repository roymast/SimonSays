using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Configurations
{
    public class ConfigurationPath : MonoBehaviour
    {
        const string ConfigFileArgKey = "-configFile";
        public ReadCommandLineArgs ReadCommandLineArgs;

        public string GetConfigurationPath()
        {
            string fileName = ReadCommandLineArgs.GetArgumentByKey(ConfigFileArgKey);
            return GetPath(fileName);
        }
        public static string GetPath(string fileName)
        {
            string filePath = Application.dataPath;

            return Path.Combine(filePath, fileName);
        }
    }
}