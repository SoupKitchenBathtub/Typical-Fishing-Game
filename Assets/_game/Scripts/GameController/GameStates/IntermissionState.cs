using UnityEngine;

public class IntermissionState : State
{

    private GameFSM _stateMachine;
    private GameController _controller;

    public IntermissionState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        //Check if previous state is day or night
        if(_stateMachine.PrevState == _stateMachine._dayState)
        {
            //Spawn Day Shop
        }
        else if (_stateMachine.PrevState == _stateMachine._nightState)
        {
            //Spawn Night Shop
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
        if (StateDur >= _controller.IntDuration)
        {
            /*switch (_stateMachine.PrevState)
            {
                case _stateMachine._dayState:
                    _stateMachine.ChangeState(_stateMachine._nightState);
                    break;
                case _stateMachine._nightState:
                    _stateMachine.ChangeState(_stateMachine._dayState);
                    break;
            }*/



            //_stateMachine.ChangeState(_stateMachine._nightState);
        }
    }
}
