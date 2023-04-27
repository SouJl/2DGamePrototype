using Root.PixelGame.Game.Core;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Weapon
{
    internal class EnemyWeapon : AbstractWeapon
    {
        private readonly string _dataPath = @"Weapon/BatScratch";
        private readonly IWeaponView _view;
        private readonly IWeaponData _data;

        private float _timeBetweenHit = 2f;
        private float _lastTimeHit;

        public EnemyWeapon(
            IWeaponView view)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            
            _data = LoadWeaponData(_dataPath);
            
            _lastTimeHit = _timeBetweenHit;

            view.Init(this);
        }

        public override void Attack()
        {
            /*if (_lastTimeHit > _timeBetweenHit)
            {
                _view.CheckTouchDamage();
                _lastTimeHit = 0;
            }
            else
            {
                _lastTimeHit += Time.deltaTime;
            }*/
            _view.CheckTouchDamage();
        }

        public override void DealDamage(IDamageable damageableObject)
        {
            damageableObject.Damage(_data.Damage);
        }
    }
}
