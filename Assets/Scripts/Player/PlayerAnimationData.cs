using UnityEngine;

public class PlayerAnimationData
{
    private string moveParameter = "Move";
    private string attackParameter = "Attack";
    private string dieParameter = "Die";

    public int MoveParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }
    public int DieParameterHash { get; private set; }

    public void Init()
    {
        MoveParameterHash = Animator.StringToHash(moveParameter);
        AttackParameterHash = Animator.StringToHash(attackParameter);
        DieParameterHash = Animator.StringToHash(dieParameter);
    }
}