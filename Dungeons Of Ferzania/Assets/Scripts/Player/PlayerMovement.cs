using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour
{

    private PlayerInput controls;
    private PlayerManager playerManager;

    [SerializeField] private float moveActionCooldown;
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    public LayerMask enemyLayer; 

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        controls = new PlayerInput();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        // Every time a WASD movement is performed, read raw value from input and run Move
        controls.Main.Movement.performed += ctx => MoveAction(ctx.ReadValue<Vector2>());
    }

    private void MoveAction(Vector2 direction)
    {
        if (CanMove(direction) && !playerManager.actionOnCooldown)
        {
            transform.position += (Vector3)direction;
            playerManager.ActionTaken(moveActionCooldown);
        }
    }

    private bool CanMove(Vector2 direction)
    {

        // Check if the destination grid has a collider
        Vector3Int gridDestination = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        // Check if the the destination has an 
        Collider2D enemyBlocksPath = Physics2D.OverlapCircle(transform.position + (Vector3)direction, 0.1f, enemyLayer); // Layermask 3 is grid layer

        if (!groundTilemap.HasTile(gridDestination) || collisionTilemap.HasTile(gridDestination) || enemyBlocksPath != null )
            return false;
        return true;
    }
}