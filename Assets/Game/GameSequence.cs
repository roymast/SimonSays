using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : MonoBehaviour
{
    public Action OnSequenceFinished;    
    IGameSequenceRepeat GameSequenceRepeat;
    [SerializeField] GameInit gameInit;
    [SerializeField] List<int> buttonsSequence = new List<int>();
    int indexInOrder = 0;
    int buttonsAmount = 0;
    // Start is called before the first frame update
    void Start()
    {        
        buttonsAmount = gameInit.GetButtonsAmount;
        GameSequenceRepeat = gameInit.GetGameSequenceRepeat();
        AddToSequence();
    }
    public void SetGameRepeat(IGameSequenceRepeat gameSequenceRepeat)
    {
        GameSequenceRepeat = gameSequenceRepeat;
    }
    private void OnEnable()
    {
        SimonButton.OnSimonButtonClick += SimonButtonClicked;
    }
    private void OnDisable()
    {
        SimonButton.OnSimonButtonClick -= SimonButtonClicked;
    }
    void SimonButtonClicked(int buttonIndex)
    {
        if (buttonsSequence[indexInOrder] == buttonIndex)
            indexInOrder++;
        if (indexInOrder >= buttonsSequence.Count)
            AddToSequence();
    }
    void AddToSequence()
    {        
        indexInOrder = 0;
        buttonsSequence.Add(UnityEngine.Random.Range(0, buttonsAmount));
        StartCoroutine(GameSequenceRepeat.RepeatSequence(buttonsSequence));
        Debug.Log("next in sequence: " + buttonsSequence[buttonsSequence.Count - 1]);
    }
}
