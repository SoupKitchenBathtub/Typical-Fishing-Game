using UnityEngine;
using DG.Tweening;

public class DayState : State
{

    private GameFSM _stateMachine;
    private GameController _controller;
    private EntitySpawnerScript _FSSpawner;
    private Light _sun;

    public DayState(GameFSM stateMachine, GameController controller, EntitySpawnerScript spawner, Light light)
    {
        _stateMachine = stateMachine;
        _controller = controller;
        _FSSpawner = spawner;
        _sun = light;
    }

    public override void Enter()
    {
        base.Enter();
        SaveManager.Instance.Load();
        Debug.Log("Day " + SaveManager.Instance.ActiveSaveData.day);
        _FSSpawner.StartSpawning();
        _sun.DOColor(new Color(1, 0.6862745f, 0.345098f), _controller.TapLimitDuration).SetEase(Ease.InOutSine);
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
        //Debug.Log("Day Time");

        if (StateDur >= _controller.TapLimitDuration)
        {
            //Clear All Objects in scene
            _FSSpawner.StopSpawning();
            _FSSpawner.DestroyAllInts();
            _stateMachine.ChangeState(_stateMachine._intState);
        }
    }
}
