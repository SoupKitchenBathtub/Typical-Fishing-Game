using UnityEngine;

[RequireComponent(typeof(Collider))]

public class DamageZone : MonoBehaviour
{

    [SerializeField] private int _damage = 10;
    [SerializeField] private float _damageFrequency = .2f;

    private Collider _triggerCollider;

    private void Awake()
    {
        _triggerCollider = GetComponent<Collider>();
        _triggerCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
            //Debug.Log("ATTACK!");
            _triggerCollider.enabled = false;
            Invoke(nameof(ReadyAttack), _damageFrequency);
        }
    }

    private void ReadyAttack()
    {
        _triggerCollider.enabled = true;
    }

}
