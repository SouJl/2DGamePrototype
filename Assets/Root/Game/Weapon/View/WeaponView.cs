using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Weapon
{
    internal interface IWeaponView 
    {
        void Init(IWeapon weapon);
        void CheckTouchDamage();
    }

    internal class WeaponView : MonoBehaviour, IWeaponView
    {
        private IWeapon _weapon;

        public void Init(IWeapon weapon)
        {
            _weapon 
                = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public void CheckTouchDamage() { }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                IDamageable damageableObject = collision.gameObject.GetComponent<EnemyView>();
                _weapon.DealDamage(damageableObject);
            }          
        }
    }
}
