using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputHandler _input;
    [SerializeField] private float _moveSpeed = 2;
    [SerializeField] private Animator _animation;
    [SerializeField] private SpriteRenderer _sprite;

    private Vector2 _moveDirection;
    private Rigidbody _rigidbody;
    private float xPosLastFrame;

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
        CharAnim();
        FlipChar();

    }

    private void FlipChar()
    {
        if(_moveDirection.x > 0f)
        {
            _sprite.flipX = true;
        }
        if (_moveDirection.x < 0f)
        {
            _sprite.flipX = false;
        }
    }

    private void CharAnim()
    {
        if (_input.TouchHeld == true && (transform.position.x != xPosLastFrame))
        {
            _animation.CrossFade("ship_horizontal_move_anim", 0, 0);
        }
        else if (_input.TouchHeld == false && (transform.position.x == xPosLastFrame))
        {
            _animation.CrossFade("ship_horizontal_idle_anim", 0, 0);
        }

        xPosLastFrame = transform.position.x;

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
