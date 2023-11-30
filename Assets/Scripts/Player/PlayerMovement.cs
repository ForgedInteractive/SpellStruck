using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    public const float Sensitivity = 1f;
    private float _yaw;
    private Vector3 _input;
    private Vector3 _movement = new Vector2(0f, 0f);
    private Vector3 _vel;

    private const float GroundDistance = 0.4f;
    private bool _isGrounded;
    
    public float speed = 1f;
    public float gravity = -9.81f;
    public float jumpForce = 10f;

    public LayerMask groundMask;
    
    private Transform _tr;
    private CharacterController _cc;

    private Transform _groundCheck;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _tr = transform;
        _cc = GetComponent<CharacterController>();
        _groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, GroundDistance, groundMask);
        _tr.eulerAngles = new Vector3(0, _tr.eulerAngles.y + _yaw, 0);
        _movement = _tr.right * _input.x + _tr.forward * _input.z;

        if (_isGrounded)
        {
            _cc.Move(Time.deltaTime * speed * _movement);
        }
        else
        {
            _cc.Move(Time.deltaTime * (speed * 0.9f) * _movement);
        }
        
        _vel.y += gravity * Time.deltaTime;
        _cc.Move(Time.deltaTime * _vel);
        
        if (_isGrounded && _vel.y < 0)
        {
            _vel.y = -2;
        }
    }

    private void OnCamera(InputValue value)
    {
        _yaw = value.Get<Vector2>().x * Sensitivity;
        CameraScript.YInput = value.Get<Vector2>().y;
    }

    private void OnMove(InputValue value)
    {
        _input = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }

    private void OnJump(InputValue value)
    {
        if (_isGrounded)
        {
            _vel.y = jumpForce;
        }
    }

    
}
