using Assets.Scripts.Logic;
using Assets.Scripts.Data.Enums;
using Assets.Scripts.Logic.Weapon;
using Assets.Scripts.Infrastructure.Services.Factory.BulletFactoryFolder;


namespace Assets.Scripts.Infrastructure.Services.Factory.WeaponFactoryFolder
{
    public class WeaponFactory : IWeaponFactory
    {
        private IBulletFactory _bulletFactory;

        public WeaponFactory(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public IWeapon CreateWeapon(WeaponID weaponID)
        {
            switch (weaponID)
            {
                case WeaponID.None:
                    return null;
                case WeaponID.Bow:
                    return new Bow(_bulletFactory);
                default:
                    return null;
            }
        }
    }
}
