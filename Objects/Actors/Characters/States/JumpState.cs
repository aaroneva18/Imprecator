using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State {

    Animator animator;
    PlayerMoveable playerMoveable;

    public JumpState(Animator animator, PlayerMoveable playerMoveable, string name) {
        this.animator = animator;
        this.playerMoveable = playerMoveable;
        this.name = name;
    }

    public override void Enter() {
        animator.Play("Jump");
    }

    public override void Execute() {
        playerMoveable.Jump(); 
    }

    public override void Exit() {
        throw new System.NotImplementedException();
    }

    public override void FixedExecute() {
        throw new System.NotImplementedException();
    }
}
