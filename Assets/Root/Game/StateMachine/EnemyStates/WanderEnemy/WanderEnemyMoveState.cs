using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;
using UnityEngine;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class WanderEnemyMoveState : EnemyMoveState
    {
        public WanderEnemyMoveState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IEnemyData data, 
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {

        }
        
        public override void Enter()
        {
            base.Enter();
            core.Physic.SetVelocityX(data.Speed * core.FacingDirection);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isPlayerInMinRange)
            {
                ChangeState(StateType.PlayerDetected);
                return;
            }
            if(isTouchingWall || !isGrounded)
            {
                core.SetFlipAfterIdle(true);
                ChangeState(StateType.IdleState);
                return;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (!core.SlopeAnaliser.IsOnSlope)
            {
                core.Physic.SetVelocityX(data.Speed * core.FacingDirection);
            }
            else if (core.SlopeAnaliser.IsOnSlope && core.SlopeAnaliser.CanWalkOnSlope)
            {
                var newVel = new Vector2(core.SlopeAnaliser.SlopeNormalPerp.x * -_xAxisInput, core.SlopeAnaliser.SlopeNormalPerp.y * -_xAxisInput) * data.Speed;
                core.Physic.SetVelocityX(newVel.x);
                core.Physic.SetVelocityY(newVel.y);
            }
        }

        

    }
}
