using Root.PixelGame.Game.Core;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Weapon
{
    internal class EnemyWeaponView : MonoBehaviour, IWeaponView
    {
        private IWeapon _weapon;

        public void Init(IWeapon weapon)
        {
            _weapon
                = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                IDamageable damageableObject = collision.gameObject.GetComponent<PlayerView>();
                _weapon.DealDamage(damageableObject);
            }
        }
    }
}
