using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    
    [SerializeField]
    private float timeLimit = 180f;
    [SerializeField]
    private float intLimit = 30f;

    [Header("Dependencies")]
    //[SerializeField]
    //private Unit _playerUnitPrefab;
    [SerializeField]
    private Transform _playerUnitSpawnLocation;
    [SerializeField]
    private EntitySpawnerScript _enemySpawner;
    [SerializeField]
    private InputBroadcaster _input;
    [SerializeField]
    private GameFSM _sMachine;

    public float TapLimitDuration => timeLimit;
    public float IntDuration => intLimit;

    public EntitySpawnerScript eSpawner => _enemySpawner;
    //public Unit PlayerUnitPrefab => _playerUnitPrefab;
    public InputBroadcaster Input => _input;

    public UnityEvent OnWin;
    public UnityEvent OnLose;

    public void EnterLose()
    {

        _sMachine.ChangeState(_sMachine.EndState);
        OnLose?.Invoke();
    }

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
