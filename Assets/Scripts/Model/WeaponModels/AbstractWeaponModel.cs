using PixelGame.Interfaces;

namespace PixelGame.Model
{
    public abstract class AbstractWeaponModel : IWeapon
    {
        private float _damage;
        private float _attackDelay;

        public float Damage { get => _damage; set => _damage = value; }
        public float AttackDelay { get => _attackDelay; set => _attackDelay = value; }

        public AbstractWeaponModel(float damage, float attackDelay) 
        {
            _damage = damage;
            _attackDelay = attackDelay;
        }

        public abstract void Attack();
    }
}
