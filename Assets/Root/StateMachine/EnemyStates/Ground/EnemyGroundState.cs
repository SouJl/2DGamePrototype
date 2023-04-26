using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;
using UnityEngine;

namespace Root.PixelGame.StateMachines.Enemy
{
    internal class EnemyGroundState : EnemyState
    {
        protected bool isGrounded;
        protected bool isTouchingWall;

        public EnemyGroundState(
            IStateHandler stateHandler,
            IEnemyCore core,
            IEnemyData data,
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {

        }

        public override void Enter()
        {
            base.Enter();
            DoChecks();
        }
        public override void Exit()
        {
            base.Exit();
            isGrounded = false;
            isTouchingWall = false;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            isGrounded = core.GroundCheck.CheckGround();
            isTouchingWall = core.WallCheck.CheckWallFront(core.FacingDirection);
        }
    }
}
