using UnityEngine;

namespace Assets.Scripts.Logic.Player
{
    public class PlayerGround
    {
        public bool IsGrounded => CheckGround();
        private Transform _transform;
        private float _raduis = 0.2f;
        private LayerMask _layerMask = (1 << LayerMask.NameToLayer("Ground"));

        public PlayerGround(Transform transform)
        {
            _transform = transform;
        }

        private bool CheckGround()
        {
            return Physics.CheckBox(_transform.position, Vector3.one/4 ,Quaternion.identity, _layerMask);
        }

        
    }
}
