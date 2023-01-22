using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private bool _isWallSlide;
        private bool _isFall;

        public PlayerJumpState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, AnimaState animaState) : base(stateMachine, animatorController, unit, animaState)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _isWallSlide = false;
            Jump();
        }

        public override void Exit()
        {
            base.Exit();
            _isWallSlide = false;
            _isFall = false;
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isWallSlide) stateMachine.ChangeState(_player.WallSlideState);
            if (_isFall) stateMachine.ChangeState(_player.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            /*if (!_doJump && _player.ContactsPoller.IsGrounded)
            {
                _isGround = true;
                return;
            }*/

            /*if (!_jumpModel.IsWallJump && !_player.ContactsPoller.IsGrounded && (_player.ContactsPoller.HasLeftContacts || _player.ContactsPoller.HasRightContacts))
            {
                _isWallSlide = true;
                return;
            }

            if (!_player.ContactsPoller.IsGrounded && _rgdBody.velocity.y < -_jumpModel.FallThershold)
            {
                _isFall = true;
                return;
            }*/

        }


        private void Jump() 
        {
           // _player.UnitComponents.Transform.Translate(Vector2.up * (_player.ContactsPoller.GroundCheckSize.y + 0.1f));
            animatorController.StartAnimation(_player.SpriteRenderer, AnimaState.InAir, true);
            _jumpModel.Jump(_player.JumpModel.JumpForse);
            isAbilityDone = true;
        }
    }
}
