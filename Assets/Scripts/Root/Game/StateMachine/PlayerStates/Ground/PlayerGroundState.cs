using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Core;
using UnityEngine;

namespace Root.PixelGame.Game.StateMachines
{
    internal class PlayerGroundState : PlayerState
    {
        private bool _isJump;
        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _isGrab;
        private bool _isAttack;

        public PlayerGroundState(
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
            _isJump = default;
            _isTouchingWall = default;
            _isGrab = default;
            _isGrounded = default;
            _isAttack = false;
        }

        public override void InputData()
        {
            base.InputData();
            _isJump = Input.GetKeyDown(KeyCode.Space);
            _isGrab = Input.GetKey(KeyCode.LeftControl);
            _isAttack = Input.GetMouseButtonDown(0);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isAttack)
            {
                ChangeState(StateType.PrimaryAtackState);
                return;
            }
            if (_isJump)
            {
                ChangeState(StateType.JumpState);
                return;
            }
            if (!_isGrounded && playerCore.Physic.CurrentVelocity.y <= 0)
            {
                ChangeState(StateType.FallState);
                return;
            }
            if (_isTouchingWall && _isGrab)
            {
                ChangeState(StateType.WallGrabState);
                return;
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            _isGrounded = playerCore.GroundCheck.CheckGround();
        }
    }
}
