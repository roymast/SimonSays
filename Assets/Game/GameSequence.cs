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
        GameManager.Instance.OnGameOver += () => ExitState();
    }
    public override void EnterState()
    {        
        SimonButton.OnSimonButtonClick += SimonButtonClicked;
    }    

    public override void ExitState()
    {        
        SimonButton.OnSimonButtonClick -= SimonButtonClicked;
    }    
    void SimonButtonClicked(int buttonIndex)
    {        
        if (current.Value != buttonIndex)
        {
            OnWrongSequence?.Invoke();            
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
    
    void AddToSequence()
    {
        buttonsSequence.AddLast(new LinkedListNode<int>(GetRandomButton()));
        current = buttonsSequence.First;        
        Debug.Log("next in sequence: " + buttonsSequence.Last.Value);
    }
    int GetRandomButton()
    {
        return UnityEngine.Random.Range(0, gameInit.GetButtonsAmount);
    }    
}
