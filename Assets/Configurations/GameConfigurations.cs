using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

namespace Configurations
{
    public class GameConfigurations : MonoBehaviour
    {
        [SerializeField] string _FilePath;
        [SerializeField] IFIleReader _FIleReader;
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
            _FIleReader.SetFileName(_FilePath);
            _FIleReader.ReadConfig(ref _Config);
        }
        string GetConfigPath()
        {            
            return configurationPath.GetConfigurationPath();
        }
    }
}