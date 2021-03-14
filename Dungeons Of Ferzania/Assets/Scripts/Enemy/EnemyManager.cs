using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] protected GameObject player;
    protected EnemyMovement enemyMovement; 

    public float DistanceFromPlayerX { get; set; }
    public float DistanceFromPlayerY { get; set; }
    public float AbsDistanceFromPlayerX { get; set; }
    public float AbsDistanceFromPlayerY { get; set; }

    void Start()
    {
        enemyMovement = GetComponent <EnemyMovement>(); 
        GameEvents.current.onActionTaken += DoAction; 
    }

    private void Update() 
    {
        GetDistanceFromPlayer();
    }

    protected void GetDistanceFromPlayer()
    {
        AbsDistanceFromPlayerX = Mathf.Abs(player.transform.position.x - this.transform.position.x);
        AbsDistanceFromPlayerY = Mathf.Abs(player.transform.position.y - this.transform.position.y);
        DistanceFromPlayerX = player.transform.position.x - this.transform.position.x;
        DistanceFromPlayerY = player.transform.position.y - this.transform.position.y;
    }
    public void DoAction()
    {
        enemyMovement.Move();
    }
}
