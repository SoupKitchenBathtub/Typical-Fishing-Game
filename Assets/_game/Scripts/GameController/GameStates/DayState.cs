using UnityEngine;

public class DayState : State
{

    private GameFSM _stateMachine;
    private GameController _controller;

    public DayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        //Start Spawning Fishing Spots
        //Switch Hud to Day Mode
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
        //Start Spawning Fishing Spots at fixed intervals
        //Rare occurance of a shop
        if(StateDur >= _controller.TapLimitDuration)
        {
            //Clear All Objects in scene
            _stateMachine.ChangeState(_stateMachine._intState);
        }
    }
}
