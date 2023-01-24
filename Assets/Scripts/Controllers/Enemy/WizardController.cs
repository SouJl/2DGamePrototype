using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.Model.Utils;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class WizardController : IExecute
    {
        private WizzardEnemyView _enemyView;
        private SpriteAnimatorController _animatorController;
        private ProtectorEnemyModel _enemy;
        private ProtectedZoneModel _protectedZone;
        private float lastTimeAiUpdate;

        public WizardController(WizzardEnemyView view, ProtectorEnemyModel enemyModel)
        {
            _enemyView = view;
            _enemy = enemyModel;

            _protectedZone = new ProtectedZoneModel(_enemyView.ProtectedZone, _enemy);

            _animatorController = new SpriteAnimatorController(_enemyView.AnimationConfig, _enemyView.AnimationSpeed);
            _animatorController.StartAnimation(_enemyView.SpriteRenderer, AnimaState.Idle, true);

            lastTimeAiUpdate = _enemy.PathfinderAI.UpdateFrameRate;
        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            if (lastTimeAiUpdate > _enemy.PathfinderAI.UpdateFrameRate)
            {
                _enemy.RecalculatePath();
                lastTimeAiUpdate = 0;
            }
            else
            {
                lastTimeAiUpdate += Time.fixedDeltaTime;
            }

            var newVel = _enemy.CalculatePath();
            _enemy.Components.RgdBody.velocity = newVel;
        }
    }
}
