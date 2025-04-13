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
        if (_controller.Input.IsTapPressed == true)
        {
            _stateMachine.ChangeState(_stateMachine._dayState);
        }
    }
}
