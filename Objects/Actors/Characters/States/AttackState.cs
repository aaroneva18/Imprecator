using UnityEngine;

public class AttackState : State
{
    public Animator animator;

    public AttackState(Animator animator, string name) {
        this.animator = animator;
        this.name = name;
    }

    public override void Enter() {
        animator.Play("Attack");
    }

    public override void Execute() {
        throw new System.NotImplementedException();
    }

    public override void Exit() {
        throw new System.NotImplementedException();
    }

    public override void FixedExecute() {
        throw new System.NotImplementedException();
    }

    
}
