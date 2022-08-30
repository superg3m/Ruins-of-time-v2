using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    public InventoryObject inventory;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    public int dashDistance = 5;
    public float _moveSpeed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(playerInput.movementInput.x * _moveSpeed, playerInput.movementInput.y * _moveSpeed);
        if (rigidbody2D.velocity.x < 0f)
        {
            transform.localScale = new Vector2(-2, 2);
        }
        else if (rigidbody2D.velocity.x > 0f)
        {
            transform.localScale = new Vector2(2, 2);
        }

        // Checks what the player's last directional key was and sets dash respectively
    }
    private void Update()
    {
        Rolling();
    }
    private void Rolling()
    {
        if (playerInput.isRolling)
        {
            if (playerInput.key == KeyCode.W) transform.position += new Vector3(playerInput.movementX, dashDistance, 0);

            else if (playerInput.key == KeyCode.A) transform.position += new Vector3(-dashDistance, playerInput.movementY, 0);

            else if (playerInput.key == KeyCode.S) transform.position += new Vector3(playerInput.movementX, -dashDistance, 0);

            else if (playerInput.key == KeyCode.D) transform.position += new Vector3(dashDistance, playerInput.movementY, 0);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}