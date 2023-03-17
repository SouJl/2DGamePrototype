using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerInAirState : PlayerState
    {
        private bool _isJump;
        private bool _isGrounded;

        public PlayerInAirState(
            IStateHandler stateHandler, 
            IPlayerCore playerCore, 
            IPlayerData playerData, 
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }
        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
            _isGrounded = false;
            _isJump = false;
        }

        public override void InputData()
        {
            base.InputData();
            _isJump = Input.GetKeyDown(KeyCode.Space);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (playerCore.Physic.Rigidbody.velocity.y < 0.01f)
            {
                if (_isGrounded)
                {
                    ChangeState(StateType.LandState);
                }
                else
                {
                    ChangeState(StateType.FallState);
                }
                return;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (Mathf.Abs(_xAxisInput) > playerData.MoveThresh)
            {
                playerCore.CheckFlip(_xAxisInput);

                playerCore.Physic.SetVelocityX(_xAxisInput * playerData.Speed);
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            _isGrounded = playerCore.GroundCheck.CheckGround();
        }
    }
}
