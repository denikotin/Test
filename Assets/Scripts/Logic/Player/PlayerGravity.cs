using UnityEngine;

namespace Assets.Scripts.Logic.Player
{
    public class PlayerGravity
    {
        public float YSpeed { get { return ApplyGravity(); }  }

        private float _ySpeed;
        private Transform _transform;
        private LayerMask _groundLayer;
        private Vector3 _groundCheckOffset;
        private float _groundCheckRaduis = 0.2f;

        public PlayerGravity(Transform transform, LayerMask ground)
        {
            _transform = transform;
            _groundLayer = ground; 
        }

        private bool GroundCheck() => 
            Physics.CheckSphere(_transform.TransformPoint(_groundCheckOffset), _groundCheckRaduis, _groundLayer);

        private float ApplyGravity()
        {
            if (GroundCheck())
            {
                return _ySpeed = 0;
            }
            else
            {
                return _ySpeed += Physics.gravity.y *Time.deltaTime;
            }
        }
    }
}
