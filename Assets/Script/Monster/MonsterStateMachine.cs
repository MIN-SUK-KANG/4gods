using UnityEngine;

public class MonsterStateMachine
{
    public MonsterState currentState { get; private set; }
    public void Init(MonsterState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    // Update is called once per frame
    public void ChangeState(MonsterState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
