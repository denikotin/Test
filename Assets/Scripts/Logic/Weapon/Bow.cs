using Assets.Scripts.Infrastructure.Services.Factory.BulletFactoryFolder;
using UnityEngine;

namespace Assets.Scripts.Logic.Weapon
{
    public class Bow : IWeapon
    {
        private IBulletFactory _bulletFactory;

        public Bow(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        } 

        public void Shoot(Transform origin)
        {
            GameObject bullet = _bulletFactory.CreateBullet();
            bullet.transform.position = origin.position;
            bullet.GetComponent<Rigidbody>().AddForce(origin.forward * 1000, ForceMode.Acceleration);
        }
    }
}
