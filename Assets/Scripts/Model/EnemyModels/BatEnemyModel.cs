using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public class BatEnemyModel : AbstractEnemyModel
    {
        private Transform _muzzle;
        public Transform Muzzle { get => _muzzle; }

        public BatEnemyModel(SpriteRenderer spriteRenderer, Collider2D collider2D, IMove movementModel, ILogicAI logicAI, Transform muzzle) : base(spriteRenderer, collider2D, movementModel, logicAI)
        {
            _muzzle = muzzle;
        }
                
        public override void Rotate(Vector3 target)
        {
            var selfDir = SpriteRenderer.transform.position;
            SpriteRenderer.flipX = selfDir.x > target.x ? true : false;
        }
    }
}
