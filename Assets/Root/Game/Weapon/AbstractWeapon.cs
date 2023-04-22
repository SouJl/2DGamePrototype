using System;

namespace Root.PixelGame.Game.Weapon
{
    internal interface IWeapon
    {
        Action WeaponActive { get; set; }
        void Attack();
    }
    internal abstract class AbstractWeapon : IWeapon
    {
        public Action WeaponActive { get; set; }

        public abstract void Attack();
    }
}
