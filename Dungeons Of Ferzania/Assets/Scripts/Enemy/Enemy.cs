using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected float moveActionDelay;
    protected EnemyMovement enemyMovement;

    virtual protected void Start()
    {
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

    public void DoAction()
    {
        StartCoroutine(DelayedAction(moveActionDelay));
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

            // Attack when in melee range
            if (Mathf.Abs(GetDistanceFromPlayerX()) == Mathf.Abs(GetDistanceFromPlayerY())) // Do not attack diagonally
                Debug.Log("Attack");
        }
    }
}
