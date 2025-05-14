using UnityEngine;

public class MonsterState
{
    protected Monster monBase;
    protected MonsterStateMachine stateMachine;
    protected Rigidbody2D rb2d;

    protected bool triggerCalled;
    protected string AnimBoolName;

    public MonsterState(Monster _mon, MonsterStateMachine _stateMachine, string _animBoolName)
    {
        monBase = _mon;
        stateMachine = _stateMachine;
        AnimBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb2d = monBase.rb2d;
        monBase.animator.SetBool(AnimBoolName, true);
    }

    public virtual void Exit()
    {
        monBase.animator.SetBool(AnimBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
