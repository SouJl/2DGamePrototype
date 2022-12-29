using PixelGame.Controllers;
using PixelGame.Enumerators;

namespace PixelGame.Model.StateMachines
{
    public class BatEnemyIdleState : EnemyState
    {
        public BatEnemyIdleState(StateMachine stateMachine, SpriteAnimatorController animatorController, AbstractEnemyModel enemy) : base(stateMachine, animatorController, enemy)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animatorController.StartAnimation(enemy.SpriteRenderer, AnimaState.Idle, true);
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

        public override void Exit()
        {
            base.Exit();
            animatorController.StopAnimation(enemy.SpriteRenderer);
        }
    }
}
