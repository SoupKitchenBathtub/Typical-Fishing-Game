using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData_", menuName = "ScriptableObjects/WeaponData")]

public class WeaponData : ScriptableObject
{

    [Header("General")]
    [SerializeField] string _name = "Default";
    [SerializeField] int _damage = 5;
    [SerializeField] float _projectileSpeed = 5;
    [SerializeField] float _lifetime = 2;
    [SerializeField] float _cooldown = 1;
    [SerializeField] Projectile _projectile = null;
    [SerializeField] AudioClip _shootSound = null;

    [Header("Detection")]
    [SerializeField] private bool _onlyFireIfNearbyTargets = false;
    [Range(1, 20)]
    [SerializeField] private bool _radialAttack = false;
    [SerializeField] private float _detectionRadius = 10;
    [SerializeField] private SphereCollider _targetFilter;

    public string Name => _name;
    public int Damage => _damage;
    public float MoveSpeed => _projectileSpeed;
    public float Lifetime => _lifetime;
    public float Cooldown => _cooldown;
    public Projectile Projectile => _projectile;
    public AudioClip ShootSound => _shootSound;
    public bool OnlyFireIfNearbyTargets => _onlyFireIfNearbyTargets;
    public bool RadialAttack => _radialAttack;
    public float DetectionRadius => _detectionRadius;
    public SphereCollider TargetFilter => _targetFilter;


}
