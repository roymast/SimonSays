using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using FileParser;

namespace Configurations
{
    public partial class GameConfigurations : MonoBehaviour
    {
        public static GameConfigurations Instance { get; private set; }
        [SerializeField] string _FilePath;        
        [SerializeField] ConfigurationPath configurationPath;
        [SerializeField] Root _Config = new Root();        

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }            
            Instance = this;
            _FilePath = configurationPath.GetConfigurationPath();
            _Config = LoadConfig(_FilePath);
            if (_Config == null || _Config.Easy == null || _Config.Medium == null || _Config.Hard == null)
            {
                _Config = FixGameConfigs.SetConfigDefaultValues();
                Debug.LogError("no config was found, default values were set");
            }
        }
        public static Root LoadConfig(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return null;

            if (filePath.Split('.').Length != 2)
                return null;

            FIleParser fileParser = FileParserFactory.GetFileReder(filePath.Split(".")[1]);
            Root config = fileParser.ParseFile(new Root(), filePath);
            config = FixGameConfigs.FixButtonsAmount(config);
            return config;
        }
        public ModeConfig GetMode(string mode)
        {
            switch (mode.ToLower())
            {
                case "easy":
                    return _Config.Easy;
                case "medium":
                    return _Config.Medium;
                case "hard":
                    return _Config.Hard;
                default:
                    return _Config.Easy;                    
            }
        }
    }
}