using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create an Action which will trigger the event i.e. onActionTaken.
// Create methods, subscribe them to that action ThisClass.current.onActionTaken += the method which should be run when event is called
// When you want to activate all subscribers, call a method here which calls onActionTaken. 

public class GameEvents : MonoBehaviour
{
    // Stop all non-player-actions if haltActions is true; 
    public bool haltActions;

    public static GameEvents current;

    private void Awake()
    {
        haltActions = false; 
        current = this;
    }

    public event Action onActionTaken; 

    public void ActionTaken() 
    {
        if(onActionTaken != null && haltActions == false)
        {
            onActionTaken();
        }
    }
}
