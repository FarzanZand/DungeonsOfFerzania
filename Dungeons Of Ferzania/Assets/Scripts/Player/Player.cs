using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected PlayerAction playerAction;

    protected virtual void Start() {
        playerAction = GetComponent<PlayerAction>();
    }
}
