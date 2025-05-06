using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputHandler _input;
    [SerializeField] private float _moveSpeed = 2;
    [SerializeField] private Animator _animation;

    private Vector2 _moveDirection;
    private Rigidbody _rigidbody;
    private bool faceRight = false;

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
        
        if(_moveDirection.x>0f)
        {
            _animation.CrossFadeInFixedTime("ship_horizontal_move_anim_right", 0.2f);
            faceRight = true;
        }
        else if(_moveDirection.x<0f)
        {
            _animation.CrossFadeInFixedTime("ship_horizontal_move_anim_left", 0.2f);
            faceRight = false;
        }
        if (_moveDirection.x == 0f && faceRight == true)
        {
            _animation.CrossFadeInFixedTime("ship_horizontal_idle_anim_right", 0.2f);
        }
        else if (_moveDirection.x == 0f && faceRight == false)
        {
            _animation.CrossFadeInFixedTime("ship_horizontal_idle_anim_left", 0.2f);
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
