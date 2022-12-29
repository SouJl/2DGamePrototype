using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public class BatEnemyModel : AbstractEnemyModel
    {
        private Transform _muzzle;
        public Transform Muzzle { get => _muzzle; }

        private float _lastAtackTime;

        public BatEnemyModel(Transform playerTrasnform, SpriteRenderer spriteRenderer, Collider2D collider2D, IMove movementModel, IWeapon weapon, Transform muzzle) : base(playerTrasnform, spriteRenderer, collider2D, movementModel, weapon)
        {
            _muzzle = muzzle;
        }
          
        public override void Attack()
        {
            base.Attack();
            _lastAtackTime = Time.time;
        }

        public override void Rotate()
        {
            var flipVector = new Vector3(0, SpriteRenderer.flipX ? 180 : 0, 0);
            var dir = PlayerTransform.position - _muzzle.position;
            var angle = Vector3.Angle(flipVector, dir);
            var axis = Vector3.Cross(flipVector, dir);
            _muzzle.rotation = Quaternion.AngleAxis(angle, axis);
        }

        public override bool CanAttack() => Time.time - _lastAtackTime >= WeponModel.AttackDelay;
    }
}
