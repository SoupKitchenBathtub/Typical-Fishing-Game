using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;

    private int _damage = 5;
    private float _moveSpeed = 2;
    private Vector3 _direction;
    AudioClip _shootSound = null;

    public void Spawn(Vector3 direction, int damage, float speed, AudioClip audio)
    {
        _direction = direction.normalized;
        _damage = damage;
        _moveSpeed = speed;
        _shootSound = audio;
        //AudioSource audioSource = AudioHelper.PlayClip2D(audio, 1, false);
        //audioSource.pitch = UnityEngine.Random.Range(.5f, 1);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
            //Debug.Log("Weapon Damage: " + _damage);
            Destroy(gameObject);
        }

    }
}
