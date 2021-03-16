using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected PlayerAction playerAction;
    protected PlayerManager playerManager;

    protected virtual void Start() {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        playerAction = GetComponent<PlayerAction>();
    }
}
