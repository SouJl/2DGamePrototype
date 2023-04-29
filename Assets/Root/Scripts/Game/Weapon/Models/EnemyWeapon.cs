using System;

namespace PixelGame.Game.Weapon
{
    internal class EnemyWeapon : AbstractWeapon
    {
        private readonly string _dataPath = @"Configs/Weapon/BatScratch";
        private readonly IWeaponView _view;
        private readonly IWeaponData _data;

        private int _attackIndex;
        public override IAttackData CurrentAttack => _data.Attacks[_attackIndex];

        public EnemyWeapon(
            IWeaponView view)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            
            _data = LoadWeaponData(_dataPath);
            
            view.Init(this);
        }

    
        public override void Attack()
        {
            if (_attackIndex + 1 > _data.Attacks.Count)
                _attackIndex = 0;

            _view.CheckTouchDamage();
            _attackIndex++;
        }
    }
}
