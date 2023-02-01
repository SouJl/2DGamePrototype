using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerClimbState : PlayerState
    {
        private Vector2 _cornerPos;
        private Vector2 _stopPos;
        private bool _isEndClimb;

        public PlayerClimbState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState, bool loop) : base(stateMachine, animatorController, unit, playerData, animaState, loop)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocityZero();
            player.UnitComponents.Transform.position = player.LedgeDetectPos;
            _cornerPos = player.ContactsPoller.DetermineCornerPos(player.FacingDirection);
            _stopPos.Set(_cornerPos.x + (player.FacingDirection * playerData.stopOffset.x), _cornerPos.y + playerData.stopOffset.y);
        }

        public override void Exit()
        {
            base.Exit();
            _isEndClimb = false;
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAnimationEnd) 
            {
                player.UnitComponents.Transform.position = _stopPos;
                stateMachine.ChangeState(player.IdleState);
            }
        }

   
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.SetVelocityZero();

            player.UnitComponents.Transform.position = Vector2.Lerp(player.UnitComponents.Transform.position, _stopPos, playerData.climbSmooth);
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
