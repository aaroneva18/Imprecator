using UnityEngine;

public class WalkState : State {

    Animator animator;
    PlayerMoveable playerMoveable;

    public WalkState(Animator p_animator, PlayerMoveable p_playerMoveable, string name) {
        animator = p_animator;
        playerMoveable = p_playerMoveable;
        this.name = name;
    }

    public override void Enter() {
        animator.Play("Walk");
    }

    public override void Execute() {
        playerMoveable.Move();
    }

    public override void FixedExecute() {}

    public override void Exit() {}
}
