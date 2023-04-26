using Root.PixelGame.Game.Core;
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
        [SerializeField] private Transform _touchDamageCheck;
        [SerializeField] private float _touchDamageWidth;
        [SerializeField] private float _touchDamageHeight;
        [SerializeField] private LayerMask _whatIsPlayer;

        private Vector2 touchDamageBotLeft, touchDamageTopRight;

        private IWeapon _weapon;

        public void Init(IWeapon weapon)
        {
            _weapon
                = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public void CheckTouchDamage()
        {
            touchDamageBotLeft.Set(
                _touchDamageCheck.position.x - (_touchDamageWidth / 2), 
                _touchDamageCheck.position.y - (_touchDamageHeight / 2));

            touchDamageTopRight.Set(
                _touchDamageCheck.position.x + (_touchDamageWidth / 2),
                _touchDamageCheck.position.y + (_touchDamageHeight / 2));

            Collider2D hit = Physics2D.OverlapArea(touchDamageBotLeft, touchDamageTopRight, _whatIsPlayer);

            if (hit != null)
            {
                IDamageable damageableObject = hit.gameObject.GetComponent<UnitView>();
                if(damageableObject != null)
                {
                    _weapon.WeaponActive?.Invoke();
                    _weapon.DealDamage(damageableObject);
                }         
            }
        }

        private void OnDrawGizmos()
        {
            if (!_touchDamageCheck) return;

            Vector2 botLeft = new Vector2(_touchDamageCheck.position.x - (_touchDamageWidth / 2), _touchDamageCheck.position.y - (_touchDamageHeight / 2));
            Vector2 botRight = new Vector2(_touchDamageCheck.position.x + (_touchDamageWidth / 2), _touchDamageCheck.position.y - (_touchDamageHeight / 2));
            Vector2 topRight = new Vector2(_touchDamageCheck.position.x + (_touchDamageWidth / 2), _touchDamageCheck.position.y + (_touchDamageHeight / 2));
            Vector2 topLeft = new Vector2(_touchDamageCheck.position.x - (_touchDamageWidth / 2), _touchDamageCheck.position.y + (_touchDamageHeight / 2));

            Gizmos.DrawLine(botLeft, botRight);
            Gizmos.DrawLine(botRight, topRight);
            Gizmos.DrawLine(topRight, topLeft);
            Gizmos.DrawLine(topLeft, botLeft);
        }
    }
}
