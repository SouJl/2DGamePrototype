using PixelGame.Animation;
using PixelGame.Game.AI;
using PixelGame.Game.Core;
using PixelGame.Game.Enemy;
using System;

namespace PixelGame.Game.StateMachines.Enemy
{
    internal class ChaserEnemyMoveState : EnemyState
    {
        protected readonly IAIBehaviour _aIBehaviour;

        private bool isPlayerInMinRange;
        
        public ChaserEnemyMoveState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IEnemyData data, 
            IAnimatorController animator,
            IAIBehaviour aIBehaviour) : base(stateHandler, core, data, animator)
        {
            _aIBehaviour
                = aIBehaviour ?? throw new ArgumentNullException(nameof(aIBehaviour));
        }

        public override void Enter()
        {
            base.Enter();
            _aIBehaviour.Init();
            _aIBehaviour.UpdateParameters(deltaTime);
            animator.StartAnimation(AnimationType.Idle);
        }

        public override void Exit()
        {
            base.Exit();
            _aIBehaviour.Deinit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (isPlayerInMinRange)
            {
                ChangeState(StateType.PlayerDetected);
                return;
            }
            if (_aIBehaviour.CheckTargetReached())
            {
                ChangeState(StateType.IdleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
           
            var newVel = _aIBehaviour.GetNewVelocity(core.Transform.position) * data.Speed;
            core.Physic.SetVelocityX(newVel.x);
            core.Physic.SetVelocityY(newVel.y);
        
            core.Rotate(fixedTime);
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            isPlayerInMinRange = core.PlayerDetection.CheckPlayerInMinRange();
        }
    }
}
