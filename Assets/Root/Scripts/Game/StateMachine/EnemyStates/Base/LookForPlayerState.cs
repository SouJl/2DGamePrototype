using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.Enemy;
using UnityEngine;

namespace PixelGame.Game.StateMachines.Enemy
{
    internal class LookForPlayerState : EnemyState
    {
        protected bool turnImmediately;
        protected bool isPlayerInMinange;
        protected bool isAllTurnsDone;
        protected bool isAllTurnsTimeDone;

        protected float lastTurnTime;
        protected int amountOfTurnsDone;

        public LookForPlayerState(
            IStateHandler stateHandler, 
            IEnemyCore core, 
            IEnemyData data, 
            IAnimatorController animator) : base(stateHandler, core, data, animator)
        {

        }

        public override void Enter()
        {
            base.Enter();
            isAllTurnsDone = false;
            isAllTurnsTimeDone = false;

            lastTurnTime = startTime;
            amountOfTurnsDone = 0;

            core.Physic.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (turnImmediately)
            {
                core.Flip();
                lastTurnTime = Time.time;
                amountOfTurnsDone++;
                turnImmediately = false;
            }
            else if (Time.time >= lastTurnTime + data.TimeBetweenTurns && !isAllTurnsDone)
            {
                core.Flip();
                lastTurnTime = Time.time;
                amountOfTurnsDone++;
            }

            if (amountOfTurnsDone >= data.AmountOfTurns)
            {
                isAllTurnsDone = true;
            }

            if (Time.time >= lastTurnTime + data.TimeBetweenTurns && isAllTurnsDone)
            {
                isAllTurnsTimeDone = true;
            }
        }


        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            core.Physic.SetVelocityX(0f);
        }

        protected override void DoChecks()
        {
            base.DoChecks();
            isPlayerInMinange = core.PlayerDetection.CheckPlayerInMinRange();
        }
    }
}
