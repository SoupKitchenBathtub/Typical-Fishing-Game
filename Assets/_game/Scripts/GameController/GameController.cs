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
    [SerializeField]
    private Unit _playerUnitPrefab;
    [SerializeField]
    private Transform _playerUnitSpawnLocation;
    [SerializeField]
    private UnitSpawner _unitSpawner;
    [SerializeField]
    private InputBroadcaster _input;

    public float TapLimitDuration => timeLimit;
    public float IntDuration => intLimit;

    public Unit PlayerUnitPrefab => _playerUnitPrefab;
    public Transform PlayerUnitSpawnLocation => _playerUnitSpawnLocation;
    public UnitSpawner UnitSpawner => _unitSpawner;
    public InputBroadcaster Input => _input;
}
