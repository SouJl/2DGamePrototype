using PixelGame.Configs;
using PixelGame.Controllers;
using PixelGame.Enumerators;
using System;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerLedgeState : PlayerState
    {
        private Vector2 _cornerPos;
        private Vector2 _startPos;
        private bool _isTouchingWall;
        private bool _isHanging;
        private bool _isCornerSpace;
        private bool _isClimb;

        public PlayerLedgeState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, PlayerData playerData, AnimaState animaState, bool loop) : base(stateMachine, animatorController, unit, playerData, animaState, loop)
        {
        }

        public override void Enter()
        {
            base.Enter();

            player.SetVelocityZero();
            player.UnitComponents.Transform.position = player.LedgeDetectPos;
            _cornerPos = player.ContactsPoller.DetermineCornerPos(player.FacingDirection);

            _startPos.Set(_cornerPos.x - (player.FacingDirection * playerData.startOffset.x), _cornerPos.y - playerData.startOffset.y);

            player.UnitComponents.Transform.position = _startPos;

            _isTouchingWall = player.ContactsPoller.CheckWallFront(player.FacingDirection);
            _isHanging = true;
        }

        public override void Exit()
        {
            base.Exit();
            _isTouchingWall = false;
            _isHanging = false;
            _isClimb = false;
        }

        public override void InputData()
        {
            base.InputData();
            _isClimb = Input.GetKeyDown(KeyCode.LeftShift);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Debug.Log(_xAxisInput);

            if((Mathf.Abs(_xAxisInput) > 0 &&_yAxisInput > 0) && _xAxisInput * player.FacingDirection > 0) 
            {
                stateMachine.ChangeState(player.ClimbState);
                return;
            }

            if(_isHanging && _yAxisInput < -playerData.fallThreshold) 
            {
                stateMachine.ChangeState(player.WallSlideState);
                return;
            }
        }


        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.SetVelocityZero();
            player.UnitComponents.Transform.position = _startPos;
        }

        protected override void DoChecks()
        {
            _isCornerSpace = player.ContactsPoller.CheckCornerSpace(_cornerPos, player.FacingDirection);
        }
    }
}
