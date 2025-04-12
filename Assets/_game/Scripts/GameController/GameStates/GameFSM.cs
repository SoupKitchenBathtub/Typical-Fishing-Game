using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{

    private GameController _controller;

    //State Variables
    public GameSetupState SetupState { get; private set; }

    public DayState _dayState { get; private set; }

    public NightState _nightState { get; private set; }

    public IntermissionState _intState { get; private set; }

    public GamePlayState PlayState { get; private set; }

    public GameEndState EndState { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<GameController>();
        //State Initialization Below Here
        SetupState = new GameSetupState(this, _controller);
        _dayState = new DayState(this, _controller);
        _nightState = new NightState(this, _controller);
        _intState = new IntermissionState(this, _controller);
        PlayState = new GamePlayState(this, _controller);
        EndState = new GameEndState(this, _controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }

}
