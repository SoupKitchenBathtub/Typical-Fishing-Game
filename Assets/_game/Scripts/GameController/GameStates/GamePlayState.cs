using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State
{

    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("State: Game Play");
        Debug.Log("Listen for Input");
        Debug.Log("Display HUD");
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
        if(_controller.Input.IsTapPressed == true)
        {
            Debug.Log("You Win!");
        }
        else if(StateDur >= _controller.TapLimitDuration)
        {
            Debug.Log("You Lose!");
            _stateMachine.ChangeState(_stateMachine.EndState);
        }
        Debug.Log("Check for Win Condition");
        Debug.Log("Check for Lose Condition");
    }
}
