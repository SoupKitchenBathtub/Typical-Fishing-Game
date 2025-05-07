using System.Collections;
using UnityEngine;

public class EntitySpawnerScript : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PlayerCharacter _playerCharacter;
    [SerializeField] private PlayerHudController _HUD;
    [SerializeField] private GameFSM _stateMachine;

    [Header("Spawn Settings")]
    [SerializeField] private Enemy[] _possibleEnemiesToSpawn;
    [SerializeField] private FishingSpot[] _possibleIntsToSpawn;
    [SerializeField] private float _spawnRate = 1;
    [SerializeField] private LayerMask _layersToTest;
    [SerializeField] private float _spawnDistanceFromPlayer = 10;
    [SerializeField] private float _spawnDistanceFromPlayerInt = 20;
    [SerializeField] private float _timeBetweenSpawnRateChange = 10;
    [SerializeField] private float _spawnRateReductionAmount = 0.1f;
    [SerializeField] private float _fishMultiplies = 1f;
    [SerializeField] private float _minSpawnRate = .2f;

    private float _timeSinceLastSpawnRateChange = 0;
    private int _maxSpawnAttempts = 4;

    private float spawnDist;

    private Coroutine _spawnRoutine;

    private void Start()
    {

    }

    private IEnumerator SpawnRoutine()
    {
        Vector3 spawnPoint;

        while (_playerCharacter != null)
        {
            yield return new WaitForSeconds(_spawnRate);

            if (_playerCharacter == null)
            {
                StopSpawning();
                yield break;
            }

            spawnPoint = GetValidWorldSpawnPoint();

            if(_stateMachine.CurrState == _stateMachine._dayState)
            {
                if (spawnPoint != Vector3.zero)
                {
                    SpawnInt(ChooseRandomInt(), spawnPoint);
                }
            }
            else if (_stateMachine.CurrState == _stateMachine._nightState)
            {
                if (spawnPoint != Vector3.zero)
                {
                    Spawn(ChooseRandomEnemy(), spawnPoint);
                }
            }

        }
    }

    public void Spawn(Enemy enemyToSpawn, Vector3 position)
    {
        Enemy newEnemy = Instantiate(enemyToSpawn, position, Quaternion.identity);
        newEnemy.Initialize(_playerCharacter);
    }

    public void SpawnInt(FishingSpot fishArea, Vector3 position)
    {
        FishingSpot newFArea = Instantiate(fishArea, position, Quaternion.identity);
        newFArea.intInitialize(_playerCharacter, _HUD);
    }

    public void StartSpawning()
    {
        if (_spawnRoutine != null)
            StopCoroutine(_spawnRoutine);
        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        if (_spawnRoutine != null)
            StopCoroutine(_spawnRoutine);
    }

    public Vector3 GetValidWorldSpawnPoint()
    {

        if (_stateMachine.CurrState == _stateMachine._nightState)
        {
            spawnDist = _spawnDistanceFromPlayer;
        }
        else if (_stateMachine.CurrState == _stateMachine._dayState)
        {
            spawnDist = _spawnDistanceFromPlayerInt;
        }

        Vector3 randomDirection = new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z).normalized;

        Vector3 playerPos = new Vector3(_playerCharacter.transform.position.x, 0, _playerCharacter.transform.position.z);

        Vector3 testPoint = playerPos + (randomDirection * spawnDist);

        Collider[] colliders = Physics.OverlapSphere(testPoint, .5f, _layersToTest);

        for (int i = 0; i < _maxSpawnAttempts; i++)
        {
            if ( colliders.Length<1 )
            {
                //Debug.Log("IT WORKS!!!");
                return testPoint;
            }
            else
            {
                testPoint = new Vector3(testPoint.z, 0, -testPoint.x);
                //print(colliders);
            }
        }
        //Debug.Log("Could not Spawn");

        return testPoint = Vector3.zero;
    }

    private Enemy ChooseRandomEnemy()
    {
        int randomEnemyIndex;

        randomEnemyIndex = Random.Range(0, _possibleEnemiesToSpawn.Length);

        return _possibleEnemiesToSpawn[randomEnemyIndex];
    }

    private FishingSpot ChooseRandomInt()
    {
        int randomFSIndex;

        randomFSIndex = Random.Range(0, _possibleIntsToSpawn.Length);

        return _possibleIntsToSpawn[randomFSIndex];
    }

    private void Update()
    {
        _timeSinceLastSpawnRateChange += Time.deltaTime;

        if (_timeSinceLastSpawnRateChange >= _timeBetweenSpawnRateChange)
        {
            _spawnRate -= _spawnRateReductionAmount;

            if (_spawnRate < _minSpawnRate)
                _spawnRate = _minSpawnRate;

            _timeSinceLastSpawnRateChange = 0;
        }
    }

    public void DestroyAllEnemies()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }

    public void DestroyAllInts()
    {
        FishingSpot[] FSs = FindObjectsByType<FishingSpot>(FindObjectsSortMode.None);

        foreach (FishingSpot FS in FSs)
        {
            Destroy(FS.gameObject);
        }
    }
}
