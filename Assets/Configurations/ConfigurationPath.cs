using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Configurations
{
    /// <summary>
    /// ConfigurationPath will get you the path to the configuration after reading it from the command line
    /// </summary>
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
            if (string.IsNullOrEmpty(fileName))
                return "";

            string filePath = Application.dataPath;
            return Path.Combine(filePath, fileName);
        }
    }
}