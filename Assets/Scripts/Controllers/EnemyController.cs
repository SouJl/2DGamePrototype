using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using System;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class EnemyController : IExecute, IDisposable
    {
        private EnemyModel _enemy;
        private BatEnemyView _view;
        private SpriteAnimatorController _animatorController;

        private Transform _muzzle;
        private IWeapon _weapon;
        private float _lastAtackTime;

        public EnemyController(BatEnemyView view) 
        {
            _view = view;
            _animatorController = new SpriteAnimatorController(_view.AnimationConfig, _view.AnimationSpeed);
            _animatorController.StartAnimation(_view.SpriteRenderer, AnimaState.Idle, true);
            
            _enemy = new EnemyModel(_view.SpriteRenderer, _view.Collider, new NoneMoveModel(), new NoneJumpModel());

             _muzzle = _view.Weapon.Muzzle;
            _weapon = new ProjectileWeponModel(_view.Weapon.Damage, _view.Weapon.AttackDelay, _muzzle, _view.Weapon.Projectile, _view.Weapon.ShootPower, _view.Weapon.ForceMode);

            _view.OnLevelObjectContact += OnCloseContact;
            _view.Locator.OnLacatorContact += OnLocatorContact;
        }

        public void Execute()
        {
            _animatorController.Update();
        }

        public void FixedExecute()
        {
            
        }


        public void OnLocatorContact(LevelObjectView target)
        {
            if (CanAttack())
            {
                var flipVector = new Vector3(0, _enemy.SpriteRenderer.flipX ? 180 : 0, 0);

                var dir = target.Transform.position - _muzzle.position;
                var angle = Vector3.Angle(flipVector, dir);
                var axis = Vector3.Cross(flipVector, dir);
                _muzzle.rotation = Quaternion.AngleAxis(angle, axis);
                _weapon.Attack();

                _lastAtackTime = Time.time;
            }
        }

        private bool CanAttack() => Time.time - _lastAtackTime >= _weapon.AttackDelay;

        public void OnCloseContact(LevelObjectView target)
        {
            Debug.Log($"{this} close contact {target.gameObject.tag}");
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnCloseContact;
            _view.Locator.OnLacatorContact -= OnLocatorContact;
        }
    }
}
