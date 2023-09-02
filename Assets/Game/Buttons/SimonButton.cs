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
    [SerializeField] AudioSource AudioSource;    
    [SerializeField] Image buttonImg;
    [SerializeField] Sprite topButton;
    [SerializeField] Sprite bottomButton;    
    public void SetIndex(int index)
    {
        myIndex = index;
    }
    public void SetColor(Color color)
    {
        buttonImg.color = color;
    }
    public void SetSound(AudioClip audioClip)
    {
        AudioSource = gameObject.GetComponent<AudioSource>();
        AudioSource.clip = audioClip;
    }    
    public void OnClick()
    {
        OnSimonButtonClick?.Invoke(myIndex);
        ClickAnimationAndSound();
    }
    public void ClickAnimationAndSound()
    {
        StartClickAnimation();
        StartClickSound();
    }
    public void StartClickSound()
    {
        AudioSource.Play();
    }
    public void StartClickAnimation()
    {
        StartCoroutine(clickAnimation());
    }
    IEnumerator clickAnimation()
    {
        buttonImg.sprite = bottomButton;
        yield return new WaitForSeconds(0.3f);
        buttonImg.sprite = topButton;
    }
}
