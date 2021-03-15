using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;

    private float moveX;
    private float moveY;

    private int relativeLocation;
    
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

        // Move closest path to player. If blocked, randomly try another direction
        if(CanMoveToLocation(direction))
        {
        transform.position += direction;
        }

        // If blocked, try randomly to go another direction
        else if(Mathf.Abs(enemyManager.DistanceFromPlayerX) > Mathf.Abs(enemyManager.DistanceFromPlayerY))
        {
            int rand = Random.Range(1, 3);
            
            if(rand == 1)
            {
                direction = new Vector3(0f, 1f, 0f);
                if(CanMoveToLocation(direction))
                    transform.position += direction;
            }
            else
            {
                direction = new Vector3(0f, -1f, 0f);
                if (CanMoveToLocation(direction))
                transform.position += direction;
            }
        }
        else if (Mathf.Abs(enemyManager.DistanceFromPlayerX) < Mathf.Abs(enemyManager.DistanceFromPlayerY))
        {
            int rand = Random.Range(1, 3);

            if (rand == 1)
            {
                direction = new Vector3(1f, 0f, 0f);
                if (CanMoveToLocation(direction))
                transform.position += direction;
            }
            else
            {
                direction = new Vector3(-1f, 0f, 0f);
                if (CanMoveToLocation(direction))
                transform.position += direction;
            }
        }
    }

    private void MoveUp()
    {
        transform.position += new Vector3(0f, 1f, 0f);
    }

    private void MoveDown()
    {
        transform.position += new Vector3(0f, -1f, 0f);
    }

    private void MoveLeft()
    {
        transform.position += new Vector3(-1f, 0f, 0f);
    }

    private void MoveRight()
    {
        transform.position += new Vector3(1f, 0f, 0f);
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

        return new Vector3(moveX, moveY, 0);
    }

    private bool CanMoveToLocation(Vector2 direction)
    {
    Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
        {
            return false;
        }
        return true;

    }
}
