using UnityEngine;

namespace Assets.Scripts.Logic.Camera
{
    public class CameraController : MonoBehaviour
    {
        public Quaternion PlanarRotation => Quaternion.Euler(0f, _rotationY, 0f);

        [SerializeField] private Transform _target;
        [SerializeField][Range(1f, 100f)] private float _cameraSpeed;
        [SerializeField][Range(0f, 90f)] private float _verticalAngle;
        [SerializeField][Range(0f, 10f)] private float _verticalOffset;
        [SerializeField][Range(0f, 10f)] private float _distanceToTarget;

        private float _rotationX;
        private float _rotationY;

        private void Start() => SetCameraPosition();

        private void Update() => SetCameraPosition();

        private void SetCameraPosition()
        {
            Quaternion targetRotaion = CreateTargetRotaion();

            Vector3 focusPosition = _target.position + Vector3.up * _verticalOffset;
            Vector3 newCameraPosition = focusPosition - targetRotaion * new Vector3(0f, 0f, _distanceToTarget);
            transform.position = newCameraPosition;
            transform.rotation = targetRotaion;
        }

        private Quaternion CreateTargetRotaion()
        {
            _rotationY += Input.GetAxis("Mouse X") * _cameraSpeed;
            _rotationX += Input.GetAxis("Mouse Y") * _cameraSpeed;
            float clampedRotationX = Mathf.Clamp(_rotationX, -_verticalAngle, _verticalAngle);
            return Quaternion.Euler(clampedRotationX, _rotationY, 0f);
        }
    }
}

