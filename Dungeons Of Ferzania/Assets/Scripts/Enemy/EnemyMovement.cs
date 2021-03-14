using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
    private EnemyManager enemyManager;
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;

    private float moveX;
    private float moveY;

    private Vector3 direction; 

    private void Start() 
    {
        groundTilemap = GameObject.Find("Ground").GetComponent<Tilemap>();
        collisionTilemap = GameObject.Find("Collider").GetComponent<Tilemap>();
        moveX = 0;
        moveY = 0;
        enemyManager = GetComponent<EnemyManager>();
    }

    public void Move()
    {
        MoveTowardsPlayer();
    }

    public void MoveTowardsPlayer()
    {
        direction = RelativeLocationToPlayer();

        if(CanMove(direction))
        transform.position += direction; 


        Debug.Log("MovingTowardsPlayer X" + moveX + "Y " + moveY );    
    }

    private Vector3 RelativeLocationToPlayer()
    {
        moveX = 0; 
        moveY = 0;

        // if the distance to the player in the x-axis is greater than in the y-axis, move enemy in the x-axis
        if (Mathf.Abs(enemyManager.DistanceFromPlayerX) > Mathf.Abs(enemyManager.DistanceFromPlayerY))
        {
            // if the player is to the right of the enemy, move enemy to the right
            if (enemyManager.DistanceFromPlayerX > 0)
            {
                moveX = 1;
            }

            // if the player is to the left of the enemy move to the left
            if (enemyManager.DistanceFromPlayerX < 0)
            {
                moveX = -1;
            }
        }

        // if the distance to the player in the x-axis is lesser than in the y-axis, move enemy in the y-axis
        if (Mathf.Abs(enemyManager.DistanceFromPlayerX) < Mathf.Abs(enemyManager.DistanceFromPlayerY))
        {
            // if the player is above the enemy, move enemy up
            if (enemyManager.DistanceFromPlayerY > 0)
            {
                moveY = 1;
            }

            // if the player is below the enemy move to the enemy down
            if (enemyManager.DistanceFromPlayerY < 0)
            {
                moveY = -1;
            }
        }

        // If the X and Y distance is equal, select a random direction
        if (Mathf.Abs(enemyManager.DistanceFromPlayerX) == Mathf.Abs(enemyManager.DistanceFromPlayerY))
        {
            moveX = 0;
            moveY = 0; 
        }
f
        return new Vector3(moveX, moveY, 0);
    }

    private bool CanMove(Vector2 direction)
    {
    Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
            return false;
        return true;

    }
}
