using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Configurations
{
    public class GameConfigurations : MonoBehaviour
    {
        public string _FileName;
        public IFIleReader _FIleReader;
        public Config _Config;

        [System.Serializable]
        public class Config
        {
            public int GameButtons;
            public int PointEachStep;
            public int GameTime;
            public bool RepeatMode;
        }

        // Start is called before the first frame update
        void Awake()
        {
            _FIleReader.SetFileName(_FileName);
            _FIleReader.ReadConfig(ref _Config);
        }


    }
}