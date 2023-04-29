using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.Enemy;
using UnityEngine;

namespace PixelGame.Game.StateMachines.Enemy
{
    internal class EnemyMoveState : EnemyGroundState
    {
        public EnemyMoveState(
            IStateHandler stateHandler,
            IEnemyCore core,
            IEnemyData data,
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {

        }

        public override void Enter()
        {
            base.Enter();
            animator.StartAnimation(AnimationType.Run);
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
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}
