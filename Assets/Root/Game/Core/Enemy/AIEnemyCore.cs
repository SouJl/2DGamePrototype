using Root.PixelGame.Game.AI;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal class AIEnemyCore : EnemyCore, IAIHandler
    {
        private IAIBehaviour _aIBehaviour;

        public AIEnemyCore(
            Transform transform, 
            IPhysicModel physic, 
            IMove mover, 
            IRotate rotator, 
            IAIBehaviour aIBehaviour) : base(transform, physic, mover, rotator)
        {
            ChangeAI(aIBehaviour);
        }

        public void ChangeAI(IAIBehaviour aIBehaviour) 
            => _aIBehaviour = aIBehaviour ?? throw new ArgumentNullException(nameof(aIBehaviour));

        public override void UpdateCoreData(float time)
        {
            base.UpdateCoreData(time);
            _aIBehaviour.UpdateParameters(time);
        }

        public override void Move(float time)
        {
            var newVel = _aIBehaviour.GetNewVelocity(transform.position) * time;
            mover.Move(newVel);
        }

        public override void Rotate(float time)
        {
            rotator.Rotate();
        }
    }
}
