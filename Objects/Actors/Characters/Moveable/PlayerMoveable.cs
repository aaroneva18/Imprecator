using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveable : Moveble
{
    private PlayerController controller;
    private PlayerInput playerInput;
    private Rigidbody2D rb2d;

    private void Awake() {
        controller = GetComponent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    public override bool CanJump() {
        if (!IsGrounded() || isOnDeadZone()) { return false; }
        return true;
    }

    public override bool CanMove() {
        if (isOnDeadZone()) { return false; }
        return canMove;
    }
    public override void Move() {
        var move = playerInput.actions["Move"];
        if (move.IsInProgress() && CanMove()) {
            Debug.Log(CanMove());
            rb2d.velocity = new Vector2(move.ReadValue<Vector2>().x * walkSpeed, rb2d.velocity.y);
        }
    }

    public override void Iddle() {
        throw new System.NotImplementedException();
    }

    public override void Jump() {
        var jump = playerInput.actions["Jump"];
        if (CanJump() && jump.IsPressed()) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

        }
    }
}
