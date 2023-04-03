using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        public PlayerMove PlayerMove;
        public PlayerAggression PlayerAggression;
        public Rigidbody Rigidbody;

        private IWeapon _currentWeapon;
        private bool _isShooting = false;

        private void Update()
        {
            if((!PlayerMove.IsMoving) && (PlayerAggression.CurrentAgressionOnbject != null))
            {
                Shoot();
            }
        }

        public void SetWeapon(IWeapon weapon)
        {
            _currentWeapon = weapon;
        }

        private void Shoot()
        {
            if (!_isShooting)
            {
                StartCoroutine(ShootRoutine());
            }
        }

        private IEnumerator ShootRoutine()
        {
            _isShooting = true;
            if (_currentWeapon != null)
            {
                Debug.Log("Shoot");
                _currentWeapon.Shoot(transform);
            }
            yield return new WaitForSeconds(1f);
            _isShooting=false;

        }
    }
}