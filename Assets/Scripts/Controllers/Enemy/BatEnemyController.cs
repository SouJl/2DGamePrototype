using Pathfinding;
using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using System;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class BatEnemyController : IExecute, IDisposable
    {
        private Transform _player;
        private AbstractAIEnemyModel<ILogicAI<Path>> _enemy;
        private BatEnemyView _view;
        private IWeapon _weapon;
        private SpriteAnimatorController _animatorController;

        private float lastTimeAiUpdate;

        public BatEnemyController(Transform player, BatEnemyView view, AbstractAIEnemyModel<ILogicAI<Path>> enemyModel, IWeapon weapon) 
        {
            _player = player;
            _view = view;
            _enemy = enemyModel;

            _animatorController = new SpriteAnimatorController(_view.AnimationConfig, _view.AnimationSpeed);
            _animatorController.StartAnimation(_view.SpriteRenderer, AnimaState.Idle, true);

            _view.OnLevelObjectContact += OnCloseContact;
            _view.Locator.OnLacatorContact += OnLocatorContact;

            _weapon = weapon;

            lastTimeAiUpdate = _enemy.LogicAI.UpdateFrameRate;
        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            _weapon.Update(Time.fixedDeltaTime);

            if (lastTimeAiUpdate > _enemy.LogicAI.UpdateFrameRate) 
            {
                _enemy.RecalculatePath(_player.position);
                lastTimeAiUpdate = 0;
            }
            else 
            {
                lastTimeAiUpdate += Time.fixedDeltaTime;
            }

            var newVel = _enemy.LogicAI.CalculatePath(_enemy.UnitComponents.RgdBody.position);
            _enemy.UnitComponents.RgdBody.velocity = newVel;
            _enemy.Rotate(_player.position);
        }

        public void OnLocatorContact(LevelObjectView target)
        {
            _weapon.Attack(_player.position);
        }

        public void OnCloseContact(LevelObjectView target)
        {
            
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnCloseContact;
            _view.Locator.OnLacatorContact -= OnLocatorContact;
        }
    }
}
