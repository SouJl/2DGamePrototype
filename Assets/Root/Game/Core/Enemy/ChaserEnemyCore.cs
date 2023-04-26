using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal class ChaserEnemyCore : EnemyCore
    {
        public ChaserEnemyCore(
            Transform transform, 
            IPhysicModel physic, 
            IMove mover, 
            IRotate rotator) : base(transform, physic, mover, rotator)
        {

        }

        public override void Rotate(float time)
        {
            rotator.Rotate();
        }

        public override bool CheckPlayerInRange()
        {
            return false;
        }
    }
}
