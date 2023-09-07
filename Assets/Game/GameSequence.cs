using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameSequence is listening the player's button clicks, 
/// checking whether it's the right button of the sequence, 
/// and adds to the sequence
/// </summary>
public class GameSequence : GameState
{
    public Action OnSequenceFinished;
    public Action OnWrongSequence;    
    public LinkedList<int> buttonsSequence { get; private set; }
    public LinkedList<int> ButtonsSequence 
    { 
        get 
        {
            if (buttonsSequence == null || buttonsSequence.Count < 1)
                InitSequence();
            return buttonsSequence;                
        }
    }
    LinkedListNode<int> current;
    // Start is called before the first frame update
    private void Awake()
    {                    
        GameManager.Instance.OnGameOver += () => ExitState();        
    }
    public void InitSequence()
    {
        buttonsSequence = new LinkedList<int>();
        AddToSequence();
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
            ExitState();
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
        return UnityEngine.Random.Range(0, GameManager.Instance.GetButtonsAmount);
    }    
}
