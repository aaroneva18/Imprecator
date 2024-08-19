using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState;
    private State previousState;
    private Dictionary<Type, List<Transition>> transitionsDictionary = new Dictionary<Type, List<Transition>>();
    private List<Transition> currentTransitions = new List<Transition>();   

    void Update()
    {
        Transition transition = getTransition();
        if (transition != null) { SetState(transition.To); Debug.Log("si hay trancision"); }
        currentState?.Execute();
    }


    public State getCurrentState { get { return currentState; } }
    public State getPreviousState { get { return previousState; } }

    private Transition getTransition() {
        foreach (Transition transition in currentTransitions) {
            if (transition.Condition()) { return transition; }
        } 
        return null;
    }

    void SetState(State state) {
        currentState?.Exit();
        previousState = currentState;
        currentState = state;

        transitionsDictionary.TryGetValue(currentState.GetType(), out currentTransitions);
        if(currentTransitions == null) { currentTransitions = new List<Transition>(0); }

        currentState.Enter();
    }

    protected void addTransition(State from, State to, Func<bool> predicate) {
        if (!transitionsDictionary.TryGetValue(from.GetType(), out List<Transition> stateTransitions)) {
            stateTransitions = new List<Transition>();
            transitionsDictionary[from.GetType()] = stateTransitions;
        }
        stateTransitions.Add(new Transition(to, predicate));
    }


}


public class Transition {
    public State To { get; }

    public Func<bool> Condition { get; }    

    public Transition(State to, Func<bool> condition) {
        To = to;
        Condition = condition;
    }
}
