using Assets.Scripts.Data.Enums;
using Assets.Scripts.Infrastructure.Services.Factory.WeaponFactoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Logic.Player
{
    public class PlayerWeapon: MonoBehaviour
    {
        [SerializeField] WeaponID WeaponID;

        private IWeapon _currentWeapon;
        private IWeaponFactory _weaponFactory;

        public void Construct(IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
        }

        private void Start()
        {
            _currentWeapon = _weaponFactory.CreateWeapon(WeaponID);
        }
    }
}
