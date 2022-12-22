using PixelGame.Controllers;

namespace PixelGame.Model.StateMachines
{
    public class State
    {
        protected AbstractUnitModel unit;
        protected StateMachine stateMachine;
        protected SpriteAnimatorController animatorController;

        protected State(AbstractUnitModel unit, StateMachine stateMachine, SpriteAnimatorController animatorController)
        {
            this.unit = unit;
            this.stateMachine = stateMachine;
            this.animatorController = animatorController;
        }

        public virtual void Enter() { }

        public virtual void InputData() { }

        public virtual void LogicUpdate() 
        {
            animatorController.Update();
        }

        public virtual void PhysicsUpdate() { }

        public virtual void Exit() { }
    }
}
