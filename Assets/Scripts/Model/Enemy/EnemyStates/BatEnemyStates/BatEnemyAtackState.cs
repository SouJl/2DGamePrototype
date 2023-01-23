using PixelGame.Controllers;

namespace PixelGame.Model.StateMachines
{
    public class BatEnemyAtackState : EnemyState
    {
        public BatEnemyAtackState(StateMachine stateMachine, SpriteAnimatorController animatorController, AbstractAIEnemyModel enemy) : base(stateMachine, animatorController, enemy)
        {

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
