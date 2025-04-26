using UnityEngine;

public class NightState : State
{

    private GameFSM _stateMachine;
    private GameController _controller;

    public NightState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        //Start Spawning Enemies
        //Switch HUD to Night Mode
    }

    public override void Exit()
    {
        SaveManager.Instance.ActiveSaveData.day++;
        SaveManager.Instance.Save();
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        //Debug.Log("Night Time");
        if (StateDur >= _controller.TapLimitDuration)
        {
            //Stop Spawning of Enemies
            //Clear Enemies & Pickups
            _stateMachine.ChangeState(_stateMachine._intState);
        }
    }
}
