using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameState is an abstract class.
/// His children are part of a state machine of the game
/// </summary>
public abstract class GameState : MonoBehaviour
{
    public abstract void EnterState();    
    public abstract void ExitState();    
}
