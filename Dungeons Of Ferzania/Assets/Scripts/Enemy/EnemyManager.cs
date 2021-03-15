using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] protected GameObject player;
    protected EnemyMovement enemyMovement;
    [SerializeField]protected float moveActionDelay; 

    public float DistanceFromPlayerX { get; set; }
    public float DistanceFromPlayerY { get; set; }

    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        GameEvents.current.onActionTaken += DoAction;
    }

    private void Update()
    {
        GetDistanceFromPlayer();
    }

    protected void GetDistanceFromPlayer()
    {
        DistanceFromPlayerX = player.transform.position.x - this.transform.position.x;
        DistanceFromPlayerY = player.transform.position.y - this.transform.position.y;
    }
    public void DoAction()
    {
        StartCoroutine(DelayedAction(moveActionDelay));
    }

    private IEnumerator DelayedAction(float waitTime)
    {
        {
            yield return new WaitForSeconds(waitTime);
            // If Long range attack = true, else move closer
            // Move closer to player if further away
            if (Mathf.Abs(DistanceFromPlayerX) > 1 || Mathf.Abs(DistanceFromPlayerY) > 1 || (Mathf.Abs(DistanceFromPlayerX) == 1 && Mathf.Abs(DistanceFromPlayerY) == 1))
            {
                enemyMovement.Move();
            }

            // Attack when in melee range
            if (Mathf.Abs(DistanceFromPlayerX) == Mathf.Abs(DistanceFromPlayerY)) // Do not attack diagonally
                Debug.Log("Attack");
        }
    }

    private void CloseAction()
    {
    }
}
