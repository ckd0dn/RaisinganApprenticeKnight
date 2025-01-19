public abstract class StateMachine
{
    private IState  currentState; // 현재 상태

    public void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
