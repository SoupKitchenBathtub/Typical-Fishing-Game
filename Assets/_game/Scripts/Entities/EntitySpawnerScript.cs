using System.Collections;
using UnityEngine;

public class EntitySpawnerScript : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PlayerCharacter _playerCharacter;

    [Header("Spawn Settings")]
    //[SerializeField] private Enemy[] _possibleEnemiesToSpawn;
    [SerializeField] private float _spawnRate = 1;
    [SerializeField] private LayerMask _layersToTest;
    [SerializeField] private float _spawnDistanceFromPlayer = 10;
    [SerializeField] private float _timeBetweenSpawnRateChange = 10;
    [SerializeField] private float _spawnRateReductionAmount = 0.1f;
    [SerializeField] private float _minSpawnRate = .2f;

    private float _timeSinceLastSpawnRateChange = 0;
    private int _maxSpawnAttempts = 4;

    private Coroutine _spawnRoutine;


}
