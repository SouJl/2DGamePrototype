using PixelGame.Animation;
using PixelGame.Game.Core;
using PixelGame.Game.Weapon;
using System;
using UnityEngine;

namespace PixelGame.Game.StateMachines.Enemy
{
    internal class AttackState : State
    {
        protected readonly IEnemyCore core;
        protected readonly IAnimatorController animator;
        protected readonly IWeapon weapon;

        protected bool isPlayerInMinRange;
        protected bool isAnimationEnd;

        public AttackState(
            IStateHandler stateHandler,
            IEnemyCore core, 
            IAnimatorController animator,
            IWeapon weapon) : base(stateHandler)
        {
            this.core
                = core ?? throw new ArgumentNullException(nameof(core));
            this.animator 
                = animator ?? throw new ArgumentNullException(nameof(animator));
            this.weapon 
                = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public override void Enter()
        {
            base.Enter();
            isAnimationEnd = false;
            core.Physic.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
            animator.StopAnimation();
        }

        public override void InputData()
        {
            base.InputData();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            animator.Update();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            DoChecks();
        }

        protected override void DoChecks()
        {
            isPlayerInMinRange = core.PlayerDetection.CheckPlayerInMinRange();
            isAnimationEnd = animator.IsAnimationEnd;
        }
    }
}
