using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected bool actionOnCooldown;
    protected PlayerManager playerManager;

    protected virtual void Start()
    {
        actionOnCooldown = false; 
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>(); 
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
