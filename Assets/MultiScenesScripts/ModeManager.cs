using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : SingletonBehaviour<ModeManager>
{
    [System.Serializable]
    public class ModeConfig
    {
        public int GameButtons;
        public int PointEachStep;
        public int GameTime;
        public bool RepeatMode;
    }
    public static string modeSelected { get; private set; }
    public static ModeConfig modeConfig;
    public static ModeConfig ModeConfigs
    {
        get
        {
            if (modeConfig == null)
            {
                modeConfig = new ModeConfig();
                modeConfig.GameButtons = 4;
                modeConfig.GameTime = 40;
                modeConfig.PointEachStep = 3;
                modeConfig.RepeatMode = true;
            }
            return modeConfig;
        }
        set { modeConfig = value; }
    }


    [SerializeField] static Configurations.GameConfigurations GameConfigurations;    
    public void SelectLevel(string level)
    {
        modeSelected = level;
        ModeConfigs = GameConfigurations.GetMode(level);
        SceneManager.LoadScene("Game");
    }    
}
