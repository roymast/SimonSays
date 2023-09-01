using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Configurations
{
    public class GameConfigurations : MonoBehaviour
    {
        public string _FileName;
        public IFIleReader _FIleReader;
        public Root _Config;        

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
            _Config = new Root();
            _FIleReader.SetFileName(_FileName);
            _FIleReader.ReadConfig(ref _Config);            
        }
    }
}