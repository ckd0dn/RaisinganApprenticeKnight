using UnityEngine;

public class MonsterAnimationData
{
    private string moveParameter = "isMoving";
    private string attackParameter = "attack";
    private string dieParameter = "die";

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