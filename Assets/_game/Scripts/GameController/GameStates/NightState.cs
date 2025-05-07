using UnityEngine;
using DG.Tweening;

public class NightState : State
{

    private GameFSM _stateMachine;
    private GameController _controller;
    private EntitySpawnerScript _enemySpawner;
    private Light _sun;

    public NightState(GameFSM stateMachine, GameController controller, EntitySpawnerScript spawner, Light light)
    {
        _stateMachine = stateMachine;
        _controller = controller;
        _enemySpawner = spawner;
        _sun = light;
    }

    public override void Enter()
    {
        base.Enter();
        _enemySpawner.StartSpawning();
        _sun.DOColor(new Color(1, 0.6862745f, 0.345098f), _controller.TapLimitDuration).SetEase(Ease.InOutSine);
        //Switch HUD to Night Mode
    }

    public override void Exit()
    {
        SaveManager.Instance.ActiveRecData.day = SaveManager.Instance.ActiveSaveData.day;
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
