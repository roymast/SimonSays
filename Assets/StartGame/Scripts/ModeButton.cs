using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ModeButton : MonoBehaviour
{
    public static Action<ModeButton> OnModeButtonClick;
    [SerializeField] Button Button;
    public string level { get; private set; }

    public void OnButtonClick()
    {
        OnModeButtonClick?.Invoke(this);        
    }
    private void Start()
    {
        level = Button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
