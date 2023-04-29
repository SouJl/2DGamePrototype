using PixelGame.Tool.PlayerSearch;
using UnityEngine;

namespace PixelGame.Game.Core
{
    internal class ChaserEnemyCore : EnemyCore
    {
        public ChaserEnemyCore(
            Transform transform, 
            IPhysicModel physic, 
            IPlayerDetection playerDetection, 
            IMove mover, 
            IRotate rotator) : base(transform, physic, playerDetection, mover, rotator)
        {
        }

        public override void Rotate(float time)
        {
            rotator.Rotate();
        }
    }
}
