using PixelGame.Game.Core;
using PixelGame.Tool;
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
        public Action<IDamageable> OnDamage { get; set; }
        public Action<IKnockbackable> OnKnockBack { get; set; }
        public Action WeaponActive { get; set; }

        public abstract IAttackData CurrentAttack { get; }

        public abstract void Attack();
  
        protected IWeaponData LoadWeaponData(string path) 
            => ResourceLoader.LoadObject<WeaponData>(path);
    }
}
