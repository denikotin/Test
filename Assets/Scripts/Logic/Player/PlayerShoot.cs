using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Player
{
    public class PlayerShoot : MonoBehaviour, IShoot
    {
        private bool _isShooting = false;

        public void Shoot(IWeapon weapon)
        {
            if (!_isShooting)
            {
                StartCoroutine(ShootRoutine(weapon));
            }
        }

        private IEnumerator ShootRoutine(IWeapon weapon)
        {
            _isShooting = true;
            if (weapon != null)
            {
                weapon.Shoot(transform);
            }
            yield return new WaitForSeconds(1f);
            _isShooting = false;
        }
    }
}