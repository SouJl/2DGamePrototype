using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;
using UnityEngine;

namespace Root.PixelGame.StateMachines.Enemy
{
    internal class EnemyMoveState : EnemyGroundState
    {
        protected bool isDetectingLedge;

        public EnemyMoveState(
            IStateHandler stateHandler,
            IEnemyCore core,
            IEnemyData data,
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {

        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.Run);
            core.Physic.SetVelocityX(data.Speed * core.FacingDirection);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

          

            if (!isGrounded)
            {
                core.Flip();
                ChangeState(StateType.IdleState);
                return;
            }
            else
            {
                if (!core.SlopeAnaliser.IsOnSlope)
                {
                    core.Move(fixedTime);
                }
                else if (core.SlopeAnaliser.IsOnSlope && core.SlopeAnaliser.CanWalkOnSlope)
                {
                    var newVel = new Vector2(core.SlopeAnaliser.SlopeNormalPerp.x * -_xAxisInput, core.SlopeAnaliser.SlopeNormalPerp.y * -_xAxisInput) * 2f;
                    core.Physic.SetVelocityX(newVel.x);
                    core.Physic.SetVelocityY(newVel.y);
                }
            }      
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
