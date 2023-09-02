using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SimonButton : MonoBehaviour
{
    public static Action<int> OnSimonButtonClick;

    [SerializeField] int myIndex;
    [SerializeField] Image buttonImg;
    [SerializeField] Sprite topButton;
    [SerializeField] Sprite bottomButton;
    public void Init(int index)
    {
        myIndex = index;
    }
    public void OnClick()
    {
        OnSimonButtonClick?.Invoke(myIndex);
        StartCoroutine(clickAnimation());
    }
    IEnumerator clickAnimation()
    {
        buttonImg.sprite = bottomButton;
        yield return new WaitForSeconds(0.3f);
        buttonImg.sprite = topButton;
    }
}
