using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        MoveDown();
    }

    private void Start() {
        GameEvents.current.onActionTaken += MoveDown; // Subscribe the MoveDown method to the list
    }

    public void MoveDown()
    {
        transform.position += new Vector3(0f,-1f, 0f);
    }
}
