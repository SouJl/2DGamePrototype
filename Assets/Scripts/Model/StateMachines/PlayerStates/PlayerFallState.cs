using PixelGame.Controllers;
using PixelGame.Enumerators;

namespace PixelGame.Model.StateMachines
{
    public class PlayerFallState : PlayerState
    {
        private bool _isGround;

        public PlayerFallState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit) : base(stateMachine, animatorController, unit)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _isGround = false;
            animatorController.StartAnimation(player.SpriteRenderer, AnimaState.Fall, true);
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isGround) stateMachine.ChangeState(player.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            player.SpriteRenderer.flipX = _xAxisInput < 0;
            _moveModel.Move(_xAxisInput);

            _isGround = player.ContactsPoller.IsGrounded;
        }

        public override void Exit()
        {
            base.Exit();
            _isGround = false;
            animatorController.StopAnimation(player.SpriteRenderer);
        }
    }
}
