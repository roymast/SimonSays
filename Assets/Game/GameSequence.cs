using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : GameState
{
    public Action OnSequenceFinished;
    public Action OnWrongSequence;
    [SerializeField] GameInit gameInit;
    public LinkedList<int> buttonsSequence { get; private set; }
    LinkedListNode<int> current;    
    // Start is called before the first frame update
    void Awake()
    {
        buttonsSequence = new LinkedList<int>();        
        AddToSequence();
    }
    public override void EnterState()
    {
        Debug.Log("Enter State");
        SimonButton.OnSimonButtonClick += SimonButtonClicked;
    }

    public override void UpdateState()
    {
    }

    public override void ExitState()
    {
        Debug.Log("Exit State");
        SimonButton.OnSimonButtonClick -= SimonButtonClicked;
    }    
    void SimonButtonClicked(int buttonIndex)
    {
        Debug.Log($"pressed: {buttonIndex} | Correct: {current.Value}");
        if (current.Value != buttonIndex)
        {            
            GameOver();
            return;
        }

        if (current.Next != null)
            current = current.Next;
        else
        {
            AddToSequence();
            OnSequenceFinished?.Invoke();
        }
    }

    private void GameOver()
    {
        OnWrongSequence?.Invoke();
        ExitState();
    }
    
    void AddToSequence()
    {
        buttonsSequence.AddLast(new LinkedListNode<int>(GetRandomButton()));
        current = buttonsSequence.First;
        ExitState();
        Debug.Log("next in sequence: " + buttonsSequence.Last.Value);
    }
    int GetRandomButton()
    {
        return UnityEngine.Random.Range(0, gameInit.GetButtonsAmount);
    }    
}
