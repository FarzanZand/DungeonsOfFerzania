using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : Enemy
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap wallsTilemap;
    [SerializeField] private Tilemap roofTilemap;
    [SerializeField] private Tilemap blockingObjects;


    protected override void Start()
    {
        base.Start();
        groundTilemap = GameObject.Find("Ground").GetComponent<Tilemap>();
        wallsTilemap = GameObject.Find("Walls").GetComponent<Tilemap>();
        roofTilemap = GameObject.Find("Roof").GetComponent<Tilemap>();
        blockingObjects = GameObject.Find("BlockingObjects").GetComponent<Tilemap>();

    }

    public void Move()
    {
        // Move when player is within range
        if (Mathf.Abs(GetDistanceFromPlayerX()) < 12 && Mathf.Abs(GetDistanceFromPlayerY()) < 12)
        {
            MoveTowardsPlayer();
        }
    }

    public void MoveTowardsPlayer()
    {
        // If distance between X and Y is equal
        if (Mathf.Abs(GetDistanceFromPlayerX()) == Mathf.Abs(GetDistanceFromPlayerY()) && Mathf.Abs(GetDistanceFromPlayerX()) >= 1f)
        {
            MoveIfXSameAsY();
        }

        // Try moving, if false, move other direction.
        // if the distance to the player in the x-axis is greater than in the y-axis, move enemy in the x-axis
        else if (Mathf.Abs(GetDistanceFromPlayerX()) > Mathf.Abs(GetDistanceFromPlayerY()))
        {
            // if the player is to the right of the enemy, move enemy to the right
            if (GetDistanceFromPlayerX() > 0)
            {
                if (!MoveRight())
                    MoveClosestYDirection();
            }

            // if the player is to the left of the enemy move to the left
            if (GetDistanceFromPlayerX() < 0)
            {
                if (!MoveLeft())
                    MoveClosestYDirection();
            }
        }

        // if the distance to the player in the x-axis is lesser than in the y-axis, move enemy in the y-axis
        else if (Mathf.Abs(GetDistanceFromPlayerX()) < Mathf.Abs(GetDistanceFromPlayerY()))
        {
            // if the player is above the enemy, move enemy up
            if (GetDistanceFromPlayerY() > 0)
            {
                if (!MoveUp())
                    MoveClosestXDirection();
            }

            // if the player is below the enemy move to the enemy down
            if (GetDistanceFromPlayerY() < 0)
            {
                if (!MoveDown())
                    MoveClosestXDirection();
            }
        }
    }

    //Checks if location to move to is valid and not blocked
    private bool CanMoveToLocation(Vector3 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell((Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || wallsTilemap.HasTile(gridPosition) || roofTilemap.HasTile(gridPosition) || blockingObjects.HasTile(gridPosition))
        {
            return false;
        }
        return true;
    }

    private bool MoveUp()
    {
        Vector3 direction = (transform.position + new Vector3(0f, 1f, 0f));
        if (CanMoveToLocation(direction))
        {
            transform.position = direction;
            return true;
        }
        else
            return false;
    }

    private bool MoveDown()
    {
        Vector3 direction = (transform.position + new Vector3(0f, -1f, 0f));
        if (CanMoveToLocation(direction))
        {
            transform.position = direction;
            return true;
        }
        return false;
    }

    private bool MoveLeft()
    {
        Vector3 direction = transform.position + new Vector3(-1f, 0f, 0f);
        if (CanMoveToLocation(direction))
        {
            transform.position = direction;
            return true;
        }
        return false;
    }

    private bool MoveRight()
    {
        Vector3 direction = (transform.position + new Vector3(1f, 0f, 0f));
        if (CanMoveToLocation(direction))
        {
            transform.position = direction;
            return true;
        }
        return false;
    }

    private void MoveClosestYDirection()
    {
        if (GetDistanceFromPlayerY() > 0)
            MoveUp();
        else
            MoveDown();
    }

    private void MoveClosestXDirection()
    {
        if (GetDistanceFromPlayerX() < 0)
            MoveLeft();
        else
            MoveRight();
    }

    // TODO
    private void MoveIfXSameAsY()
    {
        int rand = Random.Range(1, 3);

        if (GetDistanceFromPlayerX() < 0 && GetDistanceFromPlayerY() < 0)
        {
            if (rand == 1)
            {
                MoveLeft();

            }
            else if (rand == 2)
            {
                MoveDown();
            }
        }

        else if (GetDistanceFromPlayerX() < 0 && GetDistanceFromPlayerY() > 0)
        {
            if (rand == 1)
            {
                MoveLeft();
            }
            else if (rand == 2)
            {
                MoveUp();
            }
        }

        if (GetDistanceFromPlayerX() > 0 && GetDistanceFromPlayerY() > 0)
        {
            if (rand == 1)
            {
                MoveUp();
            }
            else if (rand == 2)
            {
                MoveRight();
            }
        }

        else if (GetDistanceFromPlayerX() > 0 && GetDistanceFromPlayerY() < 0)
        {
            if (rand == 1)
            {
                MoveDown();
            }
            else if (rand == 2)
            {
                MoveRight();
            }
        }
    }

}
