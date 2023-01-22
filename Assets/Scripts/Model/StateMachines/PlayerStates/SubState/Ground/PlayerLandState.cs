using PixelGame.Controllers;
using PixelGame.Enumerators;
using UnityEngine;

namespace PixelGame.Model.StateMachines
{
    public class PlayerLandState : PlayerGroundState
    {
        public PlayerLandState(StateMachine stateMachine, SpriteAnimatorController animatorController, PlayerModel unit, AnimaState animaState) : base(stateMachine, animatorController, unit, animaState)
        {

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Mathf.Abs(_xAxisInput) > _moveModel.MovingThresh)
            {
                stateMachine.ChangeState(_player.RunState);
            }
            else 
            {
                stateMachine.ChangeState(_player.IdleState);
            }
        }
    }
}
