using Assets.Scripts.Logic.Camera;
using Assets.Scripts.Logic.Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerGround _playerGround;
    [SerializeField] private CameraController _cameraController;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _angleSpeed;
    [SerializeField] private Vector3 _direction;

    private float _xAxis;
    private float _zAxis;

    private void Start()
    {
        _playerGround = new PlayerGround(transform);
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Update()
    {
        GetAxis();
    }

    private void Move()
    {
        _direction = new Vector3(_xAxis, 0, _zAxis).normalized;
        Vector3 velocity = _cameraController.PlanarRotation * _direction * _speed * Time.fixedDeltaTime;
        _rigidbody.AddForce(velocity,ForceMode.Force);
    }

    private void Rotate()
    {
        if(_direction.magnitude !=0)
            transform.rotation =Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_cameraController.PlanarRotation * _direction), Time.fixedDeltaTime * _angleSpeed);
    }

    private void Jump()
    {
        if (_playerGround.IsGrounded)
        {
            _rigidbody.AddForce(Vector3.up*_jumpForce, ForceMode.Impulse);
        }
    }
   

    private void GetAxis()
    {
        _xAxis = Input.GetAxisRaw("Horizontal");
        _zAxis = Input.GetAxisRaw("Vertical");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 pos = new Vector3(transform.position.x,
                                  transform.position.y + GetComponent<CapsuleCollider>().height / 4,
                                  transform.position.z);
        Gizmos.DrawCube(transform.position, Vector3.one/2);
    }
}
