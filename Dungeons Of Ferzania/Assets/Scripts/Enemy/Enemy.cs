using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected float moveActionDelay;
    [SerializeField] EnemyManager enemyManager;
    protected EnemyMovement enemyMovement;

    virtual protected void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        enemyMovement = GetComponent<EnemyMovement>();
        GameEvents.current.onActionTaken += DoAction;
        player = GameObject.Find("Player");
    }

    protected float GetDistanceFromPlayerX()
    {
        return player.transform.position.x - this.transform.position.x;
    }

    protected float GetDistanceFromPlayerY()
    {
        return player.transform.position.y - this.transform.position.y;
    }

    protected bool PlayerIsAdjacent()
    {
        if (Mathf.Abs(GetDistanceFromPlayerX()) == 1 && Mathf.Abs(GetDistanceFromPlayerY()) == 0 || (Mathf.Abs(GetDistanceFromPlayerX()) == 0 && Mathf.Abs(GetDistanceFromPlayerY()) == 1))
        {
        return true;
        }
        else
        {
        return false;
        }
    }

    public void DoAction()
    {
        StartCoroutine(DelayedAction(enemyManager.moveActionDelay));
    }

    private IEnumerator DelayedAction(float waitTime)
    {
        {
            yield return new WaitForSeconds(waitTime);

            // If Long range attack = true, else move closer, Move closer to player if further away
            if (Mathf.Abs(GetDistanceFromPlayerX()) > 1 || Mathf.Abs(GetDistanceFromPlayerY()) > 1 || (Mathf.Abs(GetDistanceFromPlayerX()) == 1 && Mathf.Abs(GetDistanceFromPlayerY()) == 1))
            {
                enemyMovement.Move();
            }
            else if(PlayerIsAdjacent()) // Do not attack diagonally, and player is in melee range
            Debug.Log("Attack");
        }
    }
}
