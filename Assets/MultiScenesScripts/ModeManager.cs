using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : MonoBehaviour
{
    [System.Serializable]
    public class ModeConfig
    {
        public int GameButtons;
        public int PointEachStep;
        public int GameTime;
        public bool RepeatMode;
    }

    public static ModeManager Instance { get; private set; }
    public static string modeSelected { get; private set; }
    public static ModeConfig ModeConfigs;// { get; private set; }

    [SerializeField] static Configurations.GameConfigurations GameConfigurations;    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;            
            GameConfigurations = Configurations.GameConfigurations.Instance;            
        }        
    }
    public void SelectLevel(string level)
    {
        modeSelected = level;
        ModeConfigs = GameConfigurations.GetMode(level);
        SceneManager.LoadScene("Game");
    }    
}
