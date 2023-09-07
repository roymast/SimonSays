using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ModeButton : MonoBehaviour
{    
    [SerializeField] Button Button;
    public string level { get; private set; }

    public void OnButtonClick()
    {
        ModeManager.Instance.SelectLevel(level);        
    }
    private void Start()
    {
        level = Button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
