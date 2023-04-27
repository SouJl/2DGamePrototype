using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;

namespace Root.PixelGame.Game.StateMachines.Enemy
{
    internal class EnemyGroundState : EnemyState
    {
        protected bool isGrounded;
        protected bool isTouchingWall;
        protected bool isPlayerInMinRange;
        protected float _xAxisInput;
        protected float _yAxisInput;

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
            _xAxisInput = 0f;
            _yAxisInput = 0f;
        }

        public override void InputData()
        {
            base.InputData();
            _xAxisInput = core.Physic.CurrentVelocity.x;
            _yAxisInput = core.Physic.CurrentVelocity.y;
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
            isPlayerInMinRange = core.PlayerDetection.CheckPlayerInMinRange();
        }
    }
}
