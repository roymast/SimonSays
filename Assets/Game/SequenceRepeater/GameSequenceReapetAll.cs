using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequenceReapetAll : IGameSequenceRepeat
{    
    public override IEnumerator RepeatSequence(LinkedList<int> buttonsSequence)
    {
        LinkedListNode<int> temp = buttonsSequence.First;
        yield return new WaitForSeconds(1);
        while (temp != null)
        {
            simonButtons[temp.Value].ClickAnimationAndSound();
            temp = temp.Next;
            yield return new WaitForSeconds(0.5f);
        }
        ExitState();
    }    
}
