using UnityEngine;

public class WeaponSystem : MonoBehaviour
{

    private GameController _gC;
    public string Name { get; private set; }

    int _damage = 5;
    float _projectileSpeed = 5;
    float _lifetime = 2;
    float _cooldown = 1;
    Projectile _projectile = null;
    AudioClip _shootSound = null;

    private bool _onlyFireIfNearbyTargets = false;
    private float _detectionRadius = 10;
    private bool _radialAttack = false;
    private SphereCollider _targetFilter;

    private Collider[] _targetsDetected;
    private Vector3 _direction = Vector3.zero;

    public void SetupWeapons(WeaponData data)
    {
        Name = data.Name;
        _damage = data.Damage;
        _projectileSpeed = data.MoveSpeed;
        _lifetime = data.Lifetime;
        _cooldown = data.Cooldown;
        _projectile = data.Projectile;
        _shootSound = data.ShootSound;
        _onlyFireIfNearbyTargets = data.OnlyFireIfNearbyTargets;
        _detectionRadius = data.DetectionRadius;
        _radialAttack = data.RadialAttack;
        _targetFilter = data.TargetFilter;
    }

    private void OnEnable()
    {
        _gC.OnLose.AddListener(StopFiring);
        _gC.OnWin.AddListener(StopFiring);
    }

    private void OnDisable()
    {
        _gC.OnLose.RemoveListener(StopFiring);
        _gC.OnWin.AddListener(StopFiring);
    }

    private void Awake()
    {
        _gC = FindAnyObjectByType<GameController>();
    }

    public void Attack()
    {
        if (_onlyFireIfNearbyTargets)
        {
            Collider target = null;
            target = DetectClosestTarget();
            if (target == null) return;
            _direction = target.transform.position - transform.position;
            _direction.Normalize();
        }
        if (!_onlyFireIfNearbyTargets)
        {
            Vector3 target = RandomDirection();
            _direction = target - new Vector3(transform.position.x, 0, transform.position.z);
            _direction.Normalize();
        }

        Projectile newProjectile = Instantiate(_projectile, transform.position, Quaternion.identity);
        newProjectile.Spawn(_direction, _damage, _projectileSpeed, _shootSound);
        Destroy(newProjectile.gameObject, _lifetime);
    }

    private Collider DetectClosestTarget()
    {
        //Physics.OverlapSphere(transform.position, _detectionRadius, _targetFilter, _targetsDetected);

        if (_targetsDetected == null) return null;

        Collider closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider target in _targetsDetected)
        {
            Vector3 distanceVector = target.transform.position - transform.position;

            float currentDistance = distanceVector.sqrMagnitude;
            if (currentDistance <= closestDistance)
            {
                closestTarget = target;
                closestDistance = currentDistance;
            }
        }
        return closestTarget;
    }

    private Vector3 RandomDirection()
    {
        Vector3 ranDirect = new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z).normalized;
        Vector3 ranGenerate = new Vector3(transform.position.x, 0, transform.position.z) + (ranDirect * 100);

        return ranGenerate;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }

    public void DecreaseCooldown(float amount)
    {
        _cooldown -= amount;
        if (_cooldown < 0.1f)
            _cooldown = 0.1f;
    }

    public void StopFiring()
    {
        CancelInvoke();
        Projectile[] projectilesActive = FindObjectsByType<Projectile>(FindObjectsSortMode.None);
        foreach (Projectile projectile in projectilesActive)
        {
            Destroy(projectile.gameObject);
        }
    }

    public void IncreaseDamage(int increaseAmount)
    {
        _damage += increaseAmount;
        Debug.Log("Increase Damage");
    }
    public void SpeedIncrease(int increaseAmount)
    {
        _projectileSpeed += increaseAmount;
        Debug.Log("Speed Increase");
    }

}
