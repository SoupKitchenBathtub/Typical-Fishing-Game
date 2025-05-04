using UnityEngine;

public class NightState : State
{

    private GameFSM _stateMachine;
    private GameController _controller;
    private EntitySpawnerScript _enemySpawner;

    public NightState(GameFSM stateMachine, GameController controller, EntitySpawnerScript spawner)
    {
        _stateMachine = stateMachine;
        _controller = controller;
        _enemySpawner = spawner;
    }

    public override void Enter()
    {
        base.Enter();
        _enemySpawner.StartSpawning();
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
            _enemySpawner.StopSpawning();
            _enemySpawner.DestroyAllEnemies();
            _stateMachine.ChangeState(_stateMachine._intState);
        }
    }
}
