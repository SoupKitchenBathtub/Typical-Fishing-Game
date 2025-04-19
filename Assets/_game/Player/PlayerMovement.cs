using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputHandler _input;
    [SerializeField] private float _moveSpeed = 2;

    private Vector2 _moveDirection;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_input == null) return;

        if (_input.TouchHeld)
        {
            _moveDirection = _input.TouchCurrentPosition - _input.TouchStartPosition;
            _moveDirection.Normalize();
        }
    }

    private void FixedUpdate()
    {
        if (_rigidbody == null) return;

        if (_input.TouchHeld)
        {
            Vector3 offsetPos = new Vector3(_moveDirection.x, 0, _moveDirection.y) * _moveSpeed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + offsetPos);
        }
    }

    public void Initialize(InputHandler input)
    {
        _input = input;
    }

    /*public void IncreaseSpeed(float amount)
    {
        _moveSpeed += amount;
        Debug.Log("Speed Increased: " + _moveSpeed);
    }*/

}
