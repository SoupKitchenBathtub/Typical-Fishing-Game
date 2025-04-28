using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private PlayerCharacter _player;
    [SerializeField] private float _moveSpeed = 1;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (_player == null) return;
        Vector3 direction = _player.transform.position - transform.position;
        direction.Normalize();
        Vector3 offsetPos = direction * _moveSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + offsetPos);
    }

    public void Initialize(PlayerCharacter player)
    {
        _player = player;
    }

}
