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
        private AbstractAIEnemyModel _enemyModel;
        private ProtectedZoneModel _protectedZone;
        private float lastTimeAiUpdate;

        public WizardController(WizzardEnemyView view, AbstractAIEnemyModel enemyModel, ProtectedZoneModel protectedZone)
        {
            _enemyView = view;
            _enemyModel = enemyModel;
            _protectedZone = protectedZone;

            _animatorController = new SpriteAnimatorController(_enemyView.AnimationConfig, _enemyView.AnimationSpeed);
            _animatorController.StartAnimation(_enemyView.SpriteRenderer, AnimaState.Idle, true);

            lastTimeAiUpdate = _enemyModel.LogicAI.PathfinderAI.UpdateFrameRate;
        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            if (lastTimeAiUpdate > _enemyModel.LogicAI.PathfinderAI.UpdateFrameRate)
            {
                _enemyModel.RecalculatePath();
                lastTimeAiUpdate = 0;
            }
            else
            {
                lastTimeAiUpdate += Time.fixedDeltaTime;
            }

            _enemyModel.Rotate(_enemyModel.UnitComponents.RgdBody.position);
            _enemyModel.Move();
        }
    }
}
