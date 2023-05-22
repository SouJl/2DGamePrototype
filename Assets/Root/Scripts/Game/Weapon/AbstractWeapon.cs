using PixelGame.Game.Core;
using System;

namespace PixelGame.Game.Weapon
{
    internal interface IWeapon
    {
        IAttackData CurrentAttack { get; }

        Action<IDamageable> OnDamage { get; set; }
        Action<IKnockbackable> OnKnockBack { get; set; }
      
        Action WeaponActive { get; set; }
        
        void Attack();
    }

    internal abstract class AbstractWeapon : IWeapon
    {
        protected readonly IWeaponView View;
        protected readonly IWeaponData Data;

        protected int AttackIndex;

        public Action<IDamageable> OnDamage { get; set; }
        public Action<IKnockbackable> OnKnockBack { get; set; }
        public Action WeaponActive { get; set; }

        public abstract IAttackData CurrentAttack { get; }

        public AbstractWeapon(IWeaponView view) 
        {
            View 
                = view ?? throw new ArgumentNullException(nameof(view));
            Data 
                = view.WeaponData ?? throw new ArgumentNullException(nameof(view.WeaponData));

            Init();
        }

        protected abstract void Init();

        public abstract void Attack();
    }
}
