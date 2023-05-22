using PixelGame.Animation;
using PixelGame.Tool.Audio;
using System;

namespace PixelGame.Game.Weapon
{
    internal class Sword : AbstractWeapon
    {     
        private readonly IAnimatorController _animator;

        private readonly AnimationType[] _attackAnimations = new AnimationType[] 
        {
            AnimationType.Attack1, 
            AnimationType.Attack2 
        };

        public override IAttackData CurrentAttack => Data.Attacks[AttackIndex];

        public Sword(
            IWeaponView view, 
            IAnimatorController animator) : base(view)
        {
            _animator 
                = animator ?? throw new ArgumentNullException(nameof(animator));
        }

        public override void Attack()
        {
            if (AttackIndex + 1 > Data.Attacks.Count)
                AttackIndex = 0;

            View.CheckTouchDamage();
            _animator.StartAnimation(_attackAnimations[AttackIndex]);

            PlaySound();

            AttackIndex++;
        }

        protected override void Init()
        {
            AttackIndex = 0;
            View.Init(this);
        }

        private void PlaySound() 
            => AudioManager.Instance.PlaySFX(SFXAudioType.Player, CurrentAttack.AttackName);      
    }
}
