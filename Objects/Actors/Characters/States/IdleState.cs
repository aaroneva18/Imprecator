using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    Animator animator;

    public IdleState(Animator animator, string name ) {
        this.animator = animator;
        this.name = name;
    }

    public override void Enter() {
        animator.Play("Idle");
    }

    public override void Execute() {
        Debug.Log("Buenas");
    }

    public override void Exit() {}

    public override void FixedExecute() {}

}
