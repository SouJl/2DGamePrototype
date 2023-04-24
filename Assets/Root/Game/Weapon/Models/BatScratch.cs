using Root.PixelGame.Game.Core;
using UnityEngine;

namespace Root.PixelGame.Game.Weapon
{
    internal class BatScratch : AbstractWeapon
    {
        private readonly string _dataPath = @"Weapon/BatScratch";
        private readonly IWeaponData _data;

        private float _timeBetweenHit = 2f;
        private float _lastTimeHit;

        public BatScratch(
            IWeaponView view)
        {
            _data = LoadWeaponData(_dataPath);
            _lastTimeHit = _timeBetweenHit;
            view.Init(this);
        }

        public override void Attack()
        {
            
        }

        public override void DealDamage(IDamageable damageableObject)
        {
            if(_lastTimeHit > _timeBetweenHit)
            {
                damageableObject.Damage(_data.Damage);
                _lastTimeHit = 0;
            }
            else
            {
                _lastTimeHit += Time.deltaTime;
            }
           
        }
    }
}
