﻿using PixelGame.Game.AI;
using PixelGame.Tool.PlayerSearch;
using System;
using UnityEngine;

namespace PixelGame.Game.Core
{
    internal class AIEnemyCore : EnemyCore, IAIHandler
    {
        private IAIBehaviour _aIBehaviour;

        public AIEnemyCore(
            Transform transform, 
            IPhysicModel physic, 
            IPlayerDetection playerDetection, 
            IMove mover, 
            IRotate rotator,
            IAIBehaviour aIBehaviour) : base(transform, physic, playerDetection, mover, rotator)
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
