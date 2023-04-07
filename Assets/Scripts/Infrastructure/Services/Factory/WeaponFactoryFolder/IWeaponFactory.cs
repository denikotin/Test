using Assets.Scripts.Data.Enums;
using Assets.Scripts.Logic;

namespace Assets.Scripts.Infrastructure.Services.Factory.WeaponFactoryFolder
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(WeaponID weaponID);
    }
}