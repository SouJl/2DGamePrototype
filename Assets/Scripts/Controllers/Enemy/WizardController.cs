using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class WizardController : IExecute
    {
        private Transform _targetTransform;
        private WizzardEnemyView enemyView;
        private SpriteAnimatorController _animatorController;
        private AbstractAIEnemyModel<ILogicAI<List<Transform>>> _enemy;

        private float lastTimeAiUpdate;

        public WizardController(Transform player, WizzardEnemyView view, AbstractAIEnemyModel<ILogicAI<List<Transform>>> enemyModel)
        {
            _targetTransform = player;
            enemyView = view;
            _enemy = enemyModel;

            _animatorController = new SpriteAnimatorController(enemyView.AnimationConfig, enemyView.AnimationSpeed);
            _animatorController.StartAnimation(enemyView.SpriteRenderer, AnimaState.Idle, true);

            lastTimeAiUpdate = _enemy.LogicAI.UpdateFrameRate;
        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            if (lastTimeAiUpdate > _enemy.LogicAI.UpdateFrameRate)
            {
                _enemy.RecalculatePath(Vector3.zero);
                lastTimeAiUpdate = 0;
            }
            else
            {
                lastTimeAiUpdate += Time.fixedDeltaTime;
            }

            var newVel = _enemy.LogicAI.CalculatePath(_enemy.UnitComponents.RgdBody.position);
            _enemy.UnitComponents.RgdBody.velocity = newVel;
            _enemy.Rotate(Vector3.zero);
        }
    }
}
