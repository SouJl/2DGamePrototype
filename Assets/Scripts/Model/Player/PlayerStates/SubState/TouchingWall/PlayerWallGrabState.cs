using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerWallGrabState : PlayerTouchingWallState
    {
        private Vector2 _holdPosition;

        public PlayerWallGrabState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState, bool loop) : base(stateMachine, animatorController, unit, playerData, animaState, loop)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _holdPosition = player.UnitComponents.Transform.position;
            HoldPosition();
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
            if (!isExitingState) 
            {
                if (_yAxisInput < 0 || !isGrab)
                {
                    stateMachine.ChangeState(player.WallSlideState);
                    return;
                }
            }           
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (!isExitingState) 
            {
                HoldPosition();
            }
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }

        private void HoldPosition()
        {
            player.UnitComponents.Transform.position = _holdPosition;
            player.SetVelocityX(0f);
            player.SetVelocityY(0f);
        }
    }
}
