﻿using PixelGame.Animation;
using PixelGame.Tool.Audio;
using System;

namespace PixelGame.Game.Weapon
{
    internal class Sword : AbstractWeapon
    {
        private readonly string _dataPath = @"Configs/Weapon/Sword";
        private readonly IWeaponView _view;
        private readonly IAnimatorController _animator;
        private readonly IWeaponData _data;

        private readonly AnimationType[] _attackAnimations
            = new AnimationType[] { AnimationType.Attack1, AnimationType.Attack2 };

        private int _attackIndex;
        public override IAttackData CurrentAttack => _data.Attacks[_attackIndex];

        public Sword(
            IWeaponView view, 
            IAnimatorController animator)
        {
            _view
               = view ?? throw new ArgumentNullException(nameof(view));

            _animator = animator;
            _data = LoadWeaponData(_dataPath);

            view.Init(this);
        }

        public override void Attack()
        {
            if (_attackIndex + 1 > _data.Attacks.Count)
                _attackIndex = 0;

            _view.CheckTouchDamage();
            _animator.StartAnimation(_attackAnimations[_attackIndex]);
            PlaySound();
            _attackIndex++;
        }


        private void PlaySound() 
            => AudioManager.Instance.PlaySFX(SFXAudioType.Player, CurrentAttack.AttackName);

    }
}
