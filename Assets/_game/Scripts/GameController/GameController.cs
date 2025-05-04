using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float TapLimitDuration => timeLimit;
    public float IntDuration => intLimit;

    public EntitySpawnerScript eSpawner => _enemySpawner;
    //public Unit PlayerUnitPrefab => _playerUnitPrefab;
    public InputBroadcaster Input => _input;
}
