using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using FileParser;

namespace Configurations
{
    public class GameConfigurations : MonoBehaviour
    {
        [SerializeField] string _FilePath;
        [SerializeField] IFIleParser _FIleParser;
        [SerializeField] ConfigurationPath configurationPath;
        [SerializeField] Root _Config = new Root();        

        [System.Serializable]
        public class Root
        {
            public ModeConfig Easy;
            public ModeConfig Medium;
            public ModeConfig Hard;
        }        

        [System.Serializable]
        public class ModeConfig
        {
            public int GameButtons;
            public int PointEachStep;
            public int GameTime;
            public bool RepeatMode;
        }

        void Awake()
        {
            _FilePath = GetConfigPath();
            _FIleParser = FileParserFactory.GetFileReder(_FilePath.Split(".")[1]);
            Debug.LogError(_FIleParser.GetType());
            _FIleParser.SetFileName(_FilePath);
            _Config = _FIleParser.ParseFile(_Config);
        }
        string GetConfigPath()
        {            
            return configurationPath.GetConfigurationPath();
        }
    }
}