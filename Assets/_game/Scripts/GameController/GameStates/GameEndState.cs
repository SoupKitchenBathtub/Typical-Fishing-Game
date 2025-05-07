using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : State
{

    private GameFSM _stateMachine;
    private GameController _controller;

    public GameEndState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Game Ended State Entered");
        SaveManager.Instance.Record();
        Debug.Log("Days Survived: " + SaveManager.Instance.ActiveRecData.day);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        
    }
}
