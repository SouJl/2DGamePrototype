using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;

namespace Root.PixelGame.Game.Weapon
{
    internal class Sword : AbstractWeapon
    {
        private readonly AnimationType[] _attackAnimations 
            = new AnimationType[] { AnimationType.Attack1, AnimationType.Attack2 };

        private readonly IAnimatorController _animator;
        private readonly int _maxCombo = 2;

        private int _comboIndex;
        
        public Sword(
            IWeaponView view, 
            IAnimatorController animator)
        {
            _animator = animator;
            view.Init(this);
        }

        public override void Attack()
        {
            if (_comboIndex + 1 > _maxCombo)
                _comboIndex = 0;

            _animator.StartAnimation(_attackAnimations[_comboIndex]);
            _comboIndex++;
        }

        public override void DealDamage(IDamageable damageableObject)
        {
            damageableObject.Damage(25f);
        }
    }
}
