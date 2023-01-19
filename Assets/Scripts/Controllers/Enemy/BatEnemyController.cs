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
        private AbstractEnemyModel _enemy;
        private BatEnemyView _view;
        private IWeapon _weapon;
        private SpriteAnimatorController _animatorController;

        private float lastTimeAiUpdate;

        public BatEnemyController(Transform player, BatEnemyView view, AbstractEnemyModel enemyModel, IWeapon weapon) 
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

            var newVel = _enemy.LogicAI.CalculatePath(_view.Transform.position);
            _enemy.MoveModel.Move(newVel);

            if (lastTimeAiUpdate > _enemy.LogicAI.UpdateFrameRate) 
            {
                RecalculatePath();
                lastTimeAiUpdate = 0;
            }
            else 
            {
                lastTimeAiUpdate += Time.fixedDeltaTime;
            }
        }

        public void OnLocatorContact(LevelObjectView target)
        {
            _enemy.Rotate(_player.position);

            _weapon.Attack(_player.position);
        }

        public void OnCloseContact(LevelObjectView target)
        {
            
        }

        public void RecalculatePath()
        {
            if (_enemy.LogicAI.Seeker.IsDone())
            {
                _enemy.LogicAI.Seeker.StartPath(_view.Rigidbody.position, _player.position, OnPathComplete);
            }
        }

        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _enemy.LogicAI.OnPathComplete(p);
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnCloseContact;
            _view.Locator.OnLacatorContact -= OnLocatorContact;
        }
    }
}
