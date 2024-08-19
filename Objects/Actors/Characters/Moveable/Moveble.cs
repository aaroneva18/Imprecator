using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Moveble : MonoBehaviour
{
    #region SerializeFields
    [Header("Ground Configuration")]
    [SerializeField] protected Transform feetPosition;
    [SerializeField] protected float feetRadious = 0;
    [SerializeField] protected LayerMask groundMask;
    [SerializeField] protected LayerMask deadMask;

    [Header("Movement variables")]
    [SerializeField] protected float maxVelocity = 0;
    [SerializeField] protected float mass = 0;
    [SerializeField] protected float walkSpeed = 0;
    [SerializeField] protected float runSpeed = 0;
    [SerializeField] protected bool canMove = true;

    [Header("Jump variables")]
    [SerializeField] protected float jumpForce = 0;
    [SerializeField] protected float gravityForce = Physics.gravity.y;
    #endregion

    #region Abstract methods
    public abstract void Move();
    public abstract void Jump();
    public abstract void Iddle();
    public abstract bool CanMove();
    public abstract bool CanJump();
    #endregion

    public bool IsGrounded() {
        return Physics2D.OverlapCircle(feetPosition.transform.position, feetRadious, groundMask);
    }

    public bool isOnDeadZone() {
        return Physics2D.OverlapCircle(feetPosition.transform.position, feetRadious, deadMask);
    }

}
