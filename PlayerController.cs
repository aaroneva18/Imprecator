using UnityEngine;

public class PlayerController : StateMachine {

    private Animator animator;
    private PlayerMoveable playerMoveable;

    private void Awake() {
        animator = GetComponent<Animator>();
        playerMoveable = GetComponent<PlayerMoveable>();

    }

    private void Start() {
        //States 
        State idle = new IdleState(animator, "idle");
        State walk = new WalkState(animator, playerMoveable, "walk");
        State jump = new JumpState(animator, playerMoveable, "jump");
        State attack = new AttackState(animator, "attack");


        //Transitions
        addTransition(idle, walk, ()=> playerMoveable.CanMove());
        addTransition(idle, jump, ()=> false);
        addTransition(idle, attack, ()=> false);

        addTransition(jump, idle, ()=> false);
        addTransition(jump, walk, ()=> false);

        addTransition(attack, idle, ()=> false);
        addTransition(attack, walk, ()=> false);
        addTransition(attack, jump, ()=> false);

    }
}
