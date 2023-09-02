using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInit : MonoBehaviour
{
    [SerializeField] Transform buttonsContainer;
    [SerializeField] SimonButton buttonPrefab;
    [SerializeField] SimonButton[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        CreateButtons(ModeManager.ModeConfigs.GameButtons);
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
}
