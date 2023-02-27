using Root.PixelGame.Game;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerLandState : PlayerGroundState
    {
        public PlayerLandState(
            IStateHandler stateHandler,
            IPlayerCore playerCore,
            IPlayerData playerData) : base(stateHandler, playerCore, playerData)
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
