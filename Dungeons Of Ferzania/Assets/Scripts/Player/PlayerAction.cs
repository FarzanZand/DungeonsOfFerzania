using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float moveActionCooldown;
    public float attackActionCooldown;
    public bool actionOnCooldown;
    
    protected virtual void Start()
    {
        actionOnCooldown = false;
    }

    public void ActionTaken(float actionCooldown)
    {
        actionOnCooldown = true;
        StartCoroutine(ActionCooldown(actionCooldown));
        GameEvents.current.ActionTaken(); // Run all methods subscribing to onActionTaken; 
    }

    public IEnumerator ActionCooldown(float actionCooldownTime)
    {
        {
            yield return new WaitForSeconds(actionCooldownTime);
            actionOnCooldown = false;
        }
    }
}
