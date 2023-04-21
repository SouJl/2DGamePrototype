using Root.PixelGame.Animation;
using Root.PixelGame.Game;
using Root.PixelGame.Game.Core;
using UnityEngine;

namespace Root.PixelGame.StateMachines
{
    internal class PlayerAttackState : PlayerAbilityState
    {
     
        private bool _isCombo;

        public PlayerAttackState(
            IStateHandler stateHandler, 
            IPlayerCore playerCore, 
            IPlayerData playerData, 
            IAnimatorController animator) : base(stateHandler, playerCore, playerData, animator)
        {

        }

        public override void Enter()
        {
            base.Enter();
            Attack();
        }

        public override void Exit()
        {
            base.Exit();
            _isCombo = false;
        }

        public override void InputData()
        {
            base.InputData();
        }

        private bool CheckAttackInput() => Input.GetMouseButtonDown(0);

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (isAnimationEnd)
            {
                if (CheckAttackInput())
                {
                    if (_atackIndex == 1) _atackIndex = 0;
                    else _atackIndex ++;

                    ChangeState(StateType.PrimaryAtackState);
                    return;
                }
                else
                {
                    _atackIndex = 0;
                    ChangeState(StateType.IdleState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }

        private void Attack()
        {
            switch (_atackIndex)
            {
                case 0:
                    {
                        animator.StartAnimation(AnimationType.Attack1);
                        break;
                    }
                case 1: 
                    {
                        animator.StartAnimation(AnimationType.Attack2);
                        break;
                    }
            }
       
        }
    }
}
