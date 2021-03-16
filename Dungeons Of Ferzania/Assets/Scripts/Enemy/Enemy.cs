using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject player;

    virtual protected void Start()
    {
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
}
