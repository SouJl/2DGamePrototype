using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerClimbState : PlayerState
    {
        private Vector2 _cornerPos;
        private Vector2 _startPos;
        private Vector2 _stopPos;
        private bool _isTouchingWall;
        private bool _isHanging;

        public PlayerClimbState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState) : base(stateMachine, animatorController, unit, playerData, animaState)
        {

        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocityZero();
            player.UnitComponents.Transform.position = player.LedgeDetectPos;
            _cornerPos = player.ContactsPoller.DetermineCornerPos(player.FacingDirection);

            _startPos.Set(_cornerPos.x - (player.FacingDirection * playerData.startOffset.x), _cornerPos.y - playerData.startOffset.y);
            _stopPos.Set(_cornerPos.x + (player.FacingDirection * playerData.stopOffset.x), _cornerPos.y + playerData.stopOffset.y);

            player.UnitComponents.Transform.position = _startPos;

            _isTouchingWall = player.ContactsPoller.CheckWallFront(player.FacingDirection);
            _isHanging = true;
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

            player.SetVelocityZero();
            var pos = Vector2.Lerp(player.UnitComponents.Transform.position, _stopPos, 0.1f);
            player.UnitComponents.Transform.position = pos;
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
