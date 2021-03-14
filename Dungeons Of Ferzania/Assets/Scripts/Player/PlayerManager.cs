using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    protected void ActionTaken()
    {
        GameEvents.current.ActionTaken(); // Run all methods subscribing to onActionTaken; 
    }
}
