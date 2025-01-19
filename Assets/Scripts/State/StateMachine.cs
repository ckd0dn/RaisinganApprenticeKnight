public abstract class StateMachine
{
    private IState  currentState; // ���� ����

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
