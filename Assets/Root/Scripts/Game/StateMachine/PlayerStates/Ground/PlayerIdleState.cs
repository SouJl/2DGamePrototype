using PixelGame.Animation;
using PixelGame.Game;
using PixelGame.Game.Core;
using UnityEngine;

namespace PixelGame.Game.StateMachines
{
    internal class PlayerIdleState : PlayerGroundState
    {
        private bool _isRun;
        private bool _isFall;

        public PlayerIdleState(
            IStateHandler stateHandler,
            IPlayerCore playerCore,
            IPlayerData playerData,
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {
        }

        public override void Enter()
        {
            base.Enter();
            playerCore.Physic.SetVelocityX(0f);
            animator.StartAnimation(AnimationType.Idle);
        }

        public override void Exit()
        {
            base.Exit();
            _isRun = false;
            _isFall = false;
        }

        public override void InputData()
        {
            base.InputData();
            _isRun = Mathf.Abs(_xAxisInput) > playerData.MoveThresh;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isRun) 
                ChangeState(StateType.MoveState);
            if (_isFall) ChangeState(StateType.FallState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            playerCore.Physic.ChangePhysicsMaterial(_fullFriction);
        }


        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
