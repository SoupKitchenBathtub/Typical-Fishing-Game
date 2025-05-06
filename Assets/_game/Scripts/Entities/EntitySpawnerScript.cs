using System.Collections;
using UnityEngine;

public class EntitySpawnerScript : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PlayerCharacter _playerCharacter;

    [Header("Spawn Settings")]
    [SerializeField] private Enemy[] _possibleEnemiesToSpawn;
    [SerializeField] private float _spawnRate = 1;
    [SerializeField] private LayerMask _layersToTest;
    [SerializeField] private float _spawnDistanceFromPlayer = 10;
    [SerializeField] private float _timeBetweenSpawnRateChange = 10;
    [SerializeField] private float _spawnRateReductionAmount = 0.1f;
    [SerializeField] private float _minSpawnRate = .2f;

    private float _timeSinceLastSpawnRateChange = 0;
    private int _maxSpawnAttempts = 4;

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

            if (spawnPoint != Vector3.zero)
            {
                Spawn(ChooseRandomEnemy(), spawnPoint);
            }

        }
    }

    public void Spawn(Enemy enemyToSpawn, Vector3 position)
    {
        Enemy newEnemy = Instantiate(enemyToSpawn, position, Quaternion.identity);
        newEnemy.Initialize(_playerCharacter);
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
        Vector3 randomDirection = new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z).normalized;

        Vector3 playerPos = new Vector3(_playerCharacter.transform.position.x, 0, _playerCharacter.transform.position.z);

        Vector3 testPoint = playerPos + (randomDirection * _spawnDistanceFromPlayer);

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
}
