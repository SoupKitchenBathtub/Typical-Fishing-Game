using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : State
{

    private GameFSM _stateMachine;
    private GameController _controller;

    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("State: Game Setup");
        Debug.Log("Load Save Data");
        Debug.Log("Spawn Units");
        //Load Player Values
        //_controller.UnitSpawner.Spawn(_controller.PlayerUnitPrefab, _controller.PlayerUnitSpawnLocation);
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
        _stateMachine.ChangeState(_stateMachine._dayState);
    }
}
