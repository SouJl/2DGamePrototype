using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachine
{
    internal class PlayerLandState : PlayerGroundState
    {
        public PlayerLandState(
            IStateMachine stateMachine,
            IPlayerStateHandler stateHandler,
            IPlayerData playerData) : base(stateMachine, stateHandler, playerData)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Mathf.Abs(_xAxisInput) > playerData.MoveThresh)
            {
                ChangeState(stateHandler.GetState(PlayerStateType.RunState));
            }
            else
            {
                ChangeState(stateHandler.GetState(PlayerStateType.IdleState));
            }
        }
    }
}
