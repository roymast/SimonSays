using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Repeat all the buttons that pressed
/// </summary>
public class GameSequenceReapetAll : IGameSequenceRepeat
{    
    public override IEnumerator RepeatSequence(LinkedList<int> buttonsSequence)
    {
        LinkedListNode<int> temp = buttonsSequence.First;
        yield return new WaitForSeconds(WaitTimeBeforeRepeat);
        while (temp != null)
        {
            simonButtons[temp.Value].ClickAnimationAndSound();
            temp = temp.Next;
            yield return new WaitForSeconds(WaitTimeBetweenRepeat);
        }
        ExitState();
    }    
}
