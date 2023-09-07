using Configurations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : SingletonBehaviour<ModeManager>
{    
    public static string PlayerName;
    private static GameConfigurations.ModeConfig modeConfig;
    public GameConfigurations.ModeConfig ModeConfigs
    {
        get
        {
            //just in case there is no config, set default
            if (modeConfig == null)
                modeConfig = FixGameConfigs.SetConfigDefaultValues().Easy;            
            return modeConfig;
        }
        set { modeConfig = value; }
    }
    [SerializeField] TMPro.TMP_InputField NameBox;

    static GameConfigurations GameConfigurations;
    private void Start()
    {
        GameConfigurations = FindObjectOfType<GameConfigurations>();
        if (NameBox != null && PlayerName != string.Empty)
            NameBox.text = PlayerName;
    }
    public void SelectLevel(string level)
    {        
        if (NameBox.text == string.Empty)
            return;
        PlayerName = NameBox.text;

        ModeConfigs = GameConfigurations.GetMode(level);
        SceneManager.LoadScene("Game");
    }
    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }
}
