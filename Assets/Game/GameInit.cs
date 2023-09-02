using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInit : MonoBehaviour
{
    [SerializeField] SimonButtonFactory SimonButtonFactory;    
    [SerializeField] SimonButton[] buttons;
    [SerializeField] GameSequenceRepeatFactory GameSequenceRepeatFactory;
    public int GetButtonsAmount { get { return buttons.Length; } }
    
    void Awake()
    {
        //CreateButtons(ModeManager.ModeConfigs.GameButtons);
        CreateButtons(6);        
        GameSequenceRepeatFactory = new GameSequenceRepeatFactory(buttons, true);
    }
    SimonButton[] CreateButtons(int amount)
    {
        buttons = new SimonButton[amount];
        for (int i = 0; i < amount; i++)        
            buttons[i] = SimonButtonFactory.GetSimonButtonByIndex(i);        

        return buttons;
    }            
    //public SimonButton[] GetButtons()
    //{
    //    return buttons;
    //}
    public IGameSequenceRepeat GetGameSequenceRepeat()
    {
        return GameSequenceRepeatFactory.GetGameSequenceRepeat();//ModeManager.ModeConfigs.RepeatMode);
    }
}
