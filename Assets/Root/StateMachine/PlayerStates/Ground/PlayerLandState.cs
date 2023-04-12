using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerLandState : PlayerGroundState
    {
        public PlayerLandState(
            IStateHandler stateHandler, 
            IStateMachine stateMachine, 
            IPlayerCore playerCore, 
            IPlayerData playerData, 
            IAnimatorController animator) : base(stateHandler, stateMachine, playerCore, playerData, animator)
        {
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Mathf.Abs(_xAxisInput) > playerData.MoveThresh)
            {
                ChangeState(StateType.RunState);
            }
            else
            {
                ChangeState(StateType.IdleState);
            }
        }
    }
}
