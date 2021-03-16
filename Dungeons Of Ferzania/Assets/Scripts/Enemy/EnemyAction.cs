using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : Enemy
{
    [SerializeField] EnemyManager enemyManager;
    protected EnemyMovement enemyMovement;
    
    protected override void Start()
    {
        base.Start();
        GameEvents.current.onActionTaken += DoAction;
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        enemyMovement = GetComponent<EnemyMovement>();
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
            else if (PlayerIsAdjacent()) // Do not attack diagonally, and player is in melee range
                Debug.Log("Attack");
        }
    }
}
