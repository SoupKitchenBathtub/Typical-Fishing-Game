using DG.Tweening;
using UnityEngine;

public class IntermissionState : State
{

    private GameFSM _stateMachine;
    private GameController _controller;
    private Light _sun;

    public IntermissionState(GameFSM stateMachine, GameController controller, Light light)
    {
        _stateMachine = stateMachine;
        _controller = controller;
        _sun = light;
    }

    public override void Enter()
    {
        base.Enter();
        //Check if previous state is day or night
        if(_stateMachine.PrevState == _stateMachine._dayState)
        {
            Debug.Log("Night is Coming");
            _sun.DOColor(new Color(0, 0.2470588f, 0.4156863f), _controller.IntDuration).SetEase(Ease.InOutSine);
        }
        else if (_stateMachine.PrevState == _stateMachine._nightState)
        {
            SaveManager.Instance.ActiveSaveData.day++;
            SaveManager.Instance.Save();
            SaveManager.Instance.ActiveRecData.day = SaveManager.Instance.ActiveSaveData.day;
            SaveManager.Instance.ActiveRecData.fish = SaveManager.Instance.ActiveSaveData.fish;
            SaveManager.Instance.ActiveRecData.level= SaveManager.Instance.ActiveSaveData.level;
            SaveManager.Instance.ActiveRecData.gold = SaveManager.Instance.ActiveSaveData.gold;
            SaveManager.Instance.Record();
            Debug.Log("Day is Close");
            _sun.DOColor(new Color(1, 1, 1), _controller.IntDuration).SetEase(Ease.InOutSine);
        }
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
        //Debug.Log("Intermission Time");

        if (StateDur >= _controller.IntDuration)
        {

            if(_stateMachine.PrevState == _stateMachine._dayState)
            {
                _stateMachine.ChangeState(_stateMachine._nightState);
            }
            if (_stateMachine.PrevState == _stateMachine._nightState)
            {
                _stateMachine.ChangeState(_stateMachine._dayState);
            }

        }
    }
}
