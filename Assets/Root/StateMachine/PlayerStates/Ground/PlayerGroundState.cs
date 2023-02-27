using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerGroundState : PlayerState
    {
        private bool _isJump;
        private bool _isGrounded;
        private bool _isTouchingWall;
        private bool _isGrab;

        public PlayerGroundState(
            IStateHandler stateHandler,
            IPlayerCore playerCore,
            IPlayerData playerData) : base(stateHandler, playerCore, playerData) { }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
            _isJump = false;
            _isTouchingWall = false;
            _isGrab = false;
        }

        public override void InputData()
        {
            base.InputData();
            _isJump = Input.GetKeyDown(KeyCode.Space);
            _isGrab = Input.GetKey(KeyCode.LeftControl);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isJump)
            {
                ChangeState(StateType.JumpState);
                return;
            }
            if (!_isGrounded && playerCore.CurrentVelocity.y <= 0)
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
    }
}
