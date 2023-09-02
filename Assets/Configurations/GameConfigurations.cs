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
        public static GameConfigurations Instance { get; private set; }
        [SerializeField] string _FilePath;
        [SerializeField] IFIleParser _FIleParser;
        [SerializeField] ConfigurationPath configurationPath;
        [SerializeField] Root _Config = new Root();        

        [System.Serializable]
        public class Root
        {
            public ModeManager.ModeConfig Easy;
            public ModeManager.ModeConfig Medium;
            public ModeManager.ModeConfig Hard;
        }                

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }            
            Instance = this;            
            try
            {
                _FilePath = configurationPath.GetConfigurationPath();
                _FIleParser = FileParserFactory.GetFileReder(_FilePath.Split(".")[1]);
                Debug.LogError(_FIleParser.GetType());
                _FIleParser.SetFileName(_FilePath);
                _Config = _FIleParser.ParseFile(_Config);
                FixGameConfigs.FixButtonsAmount(_Config);
            }
            catch (Exception)
            {
                FixGameConfigs.SetConfigDefaultValues(_Config);
                throw;
            }            
        }
        private void Start()
        {
            if (_Config.Easy == null || _Config.Medium == null || _Config.Hard == null)
                FixGameConfigs.SetConfigDefaultValues(_Config);            
        }                
        public ModeManager.ModeConfig GetMode(string mode)
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