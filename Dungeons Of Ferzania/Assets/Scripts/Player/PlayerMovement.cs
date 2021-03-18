using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerMovement : Player
{

    private PlayerInput controls;
    private Vector3 destination;
    private bool movePlayer;

    [SerializeField] private float moveSpeed;
    private Tilemap groundTilemap;
    private Tilemap wallsTilemap;
    private Tilemap roofTilemap;
    private Tilemap blockingObjectsTilemap;

    public LayerMask enemyLayer;
    public LayerMask blockingObjectLayer;

    protected override void Start()
    {
        base.Start();
        // Every time a WASD movement is performed, read raw value from input and run Move
        controls.Main.Movement.performed += ctx => MoveAction(ctx.ReadValue<Vector2>());

        groundTilemap = GameObject.Find("Ground").GetComponent<Tilemap>();
        wallsTilemap = GameObject.Find("Walls").GetComponent<Tilemap>();
        roofTilemap = GameObject.Find("Roof").GetComponent<Tilemap>();
        blockingObjectsTilemap = GameObject.Find("BlockingObjects").GetComponent<Tilemap>();
    }
    private void Awake()
    {
        movePlayer = false;
        controls = new PlayerInput();
    }

    private void Update()
    {
        if (movePlayer)
            transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
        if (transform.position == destination)
            movePlayer = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    private void MoveAction(Vector2 direction)
    {
        if (CanMove(direction) && !playerAction.actionOnCooldown)
        {
            destination = transform.position + (Vector3)direction;
            movePlayer = true;
            playerAction.ActionTaken(playerAction.moveActionCooldown);
        }
    }

    private bool CanMove(Vector2 direction)
    {
        // Check if the destination grid has a collider
        Vector3Int gridDestination = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        // Check if the the destination has an 
        Collider2D enemyBlocksPath = Physics2D.OverlapCircle(transform.position + (Vector3)direction, 0.1f, enemyLayer);
        Collider2D objectBlocksPath = Physics2D.OverlapCircle(transform.position + (Vector3)direction, 0.1f, blockingObjectLayer);

        if (!groundTilemap.HasTile(gridDestination) || wallsTilemap.HasTile(gridDestination) || enemyBlocksPath != null || roofTilemap.HasTile(gridDestination) || blockingObjectsTilemap.HasTile(gridDestination) || objectBlocksPath != null)
            return false;
        return true;
    }
}