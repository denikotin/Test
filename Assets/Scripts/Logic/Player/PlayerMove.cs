using Assets.Scripts.Logic.Camera;
using UnityEngine;

namespace Assets.Scripts.Logic.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField][Range(1f, 100f)] private float _speed;
        [SerializeField][Range(100f, 1000f)] float _rotationSpeed;

        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private CameraController _camera;
        [SerializeField] private CharacterController _characterController;

        private Quaternion _targetRotation;
        private PlayerGravity _gravity;


        private void Start() => _gravity = new PlayerGravity(transform, _groundLayer);

        private void Update() => Move();

        private void Move()
        {
            float axisZ = Input.GetAxisRaw("Vertical");
            float axisX = Input.GetAxisRaw("Horizontal");
            float axisAmount = Mathf.Abs(axisX) + Mathf.Abs(axisZ);

            Vector3 movement = new Vector3(axisX, 0f, axisZ).normalized;
            Vector3 movementDirection = _camera.PlanarRotation * movement;

            Vector3 velocity = movementDirection * _speed;
            velocity.y = _gravity.YSpeed;
            _characterController.Move(velocity * Time.deltaTime);

            if (axisAmount > 0)
            {
                _targetRotation = Quaternion.LookRotation(movementDirection);
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}

