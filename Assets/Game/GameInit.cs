using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInit : MonoBehaviour
{
    [SerializeField] Transform buttonsContainer;
    [SerializeField] SimonButton buttonPrefab;
    [SerializeField] SimonButton[] buttons;
    public int GetButtonsAmount { get { return buttons.Length; } }
    
    void Awake()
    {
        //CreateButtons(ModeManager.ModeConfigs.GameButtons);
        CreateButtons(4);
    }
    SimonButton[] CreateButtons(int amount)
    {
        buttons = new SimonButton[amount];
        for (int i = 0; i < amount; i++)
        {
            buttons[i] = Instantiate(buttonPrefab, buttonsContainer);
            buttons[i].Init(i);
        }
        return buttons;
    }            
    public SimonButton[] GetButtons()
    {
        return buttons;
    }
}
