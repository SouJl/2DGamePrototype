

namespace Root.PixelGame.Game.Weapon
{
    internal interface IWeapon
    {
        void Attack();
    }
    internal abstract class AbstractWeapon : IWeapon
    {
        public abstract void Attack();
    }
}
