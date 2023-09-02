using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModeButton : MonoBehaviour
{    
    [SerializeField] Button Button;
    string level;

    public void OnButtonClick()
    {
        ModeManager.Instance.SelectLevel(level);
    }
    private void Start()
    {
        level = Button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
