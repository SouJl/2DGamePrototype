using Root.PixelGame.Game.Core;
using Root.PixelGame.Tool;
using System;

namespace Root.PixelGame.Game.Weapon
{
    internal interface IWeapon
    {
        Action WeaponActive { get; set; }
        void Attack();

        void DealDamage(IDamageable damageableObject);
        void DealKnockback(IKnockbackable knockbackableObject);
    }
    internal abstract class AbstractWeapon : IWeapon
    {
        public Action WeaponActive { get; set; }

        public abstract void Attack();

        public abstract void DealDamage(IDamageable damageableObject);
        public abstract void DealKnockback(IKnockbackable knockbackableObject);

        protected IWeaponData LoadWeaponData(string path) 
            => ResourceLoader.LoadObject<WeaponData>(path);
    }
}
