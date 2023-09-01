using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigurationPath : MonoBehaviour
{
    const string ConfigFileArgKey = "-configFile";
    const int FilePathCommandLineIndex = 0;
    public ReadCommandLineArgs ReadCommandLineArgs;

    public string GetConfigurationPath()
    {        
        string fileName = ReadCommandLineArgs.GetArgument(ConfigFileArgKey);
        Debug.LogError("Application.dataPath " + Application.dataPath);        
        string filePath = Application.dataPath;//ReadCommandLineArgs.GetArgumentByIndex(FilePathCommandLineIndex);        
        
        Debug.LogError("FileFullPath: "+Path.Combine(filePath, fileName));
        return Path.Combine(filePath, fileName);
    }
}
