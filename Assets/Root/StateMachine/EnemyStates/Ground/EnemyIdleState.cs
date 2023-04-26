using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Enemy;
using UnityEngine;

namespace Root.PixelGame.StateMachines.Enemy
{
    internal class EnemyIdleState : EnemyGroundState
    {
        public EnemyIdleState(
            IStateHandler stateHandler,
            IEnemyCore core,
            IEnemyData data,
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {

        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.Idle);
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

            if (Mathf.Abs(_xAxisInput) > data.MoveThresh)
            {
                ChangeState(StateType.MoveState);
                return;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            core.Move(fixedTime);
        }

    }
}
