using PixelGame.Controllers;

namespace PixelGame.Model.StateMachines
{
    public class EnemyState : State
    {
        protected EnemyModel enemy;

        public EnemyState(StateMachine stateMachine, SpriteAnimatorController animatorController, EnemyModel enemy) : base(stateMachine, animatorController)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
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
        }

    }
}
