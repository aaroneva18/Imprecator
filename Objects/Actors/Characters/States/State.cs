public abstract class State {

    public string name;

    public abstract void Enter();
    public abstract void Execute();
    public abstract void FixedExecute();
    public abstract void Exit();
}
