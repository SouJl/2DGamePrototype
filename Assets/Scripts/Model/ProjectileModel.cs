using System;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model
{
    public class ProjectileModel : IDisposable
    {
        private Transform _transform;
        private Rigidbody2D _rgdbody;

        private float _damage;
        private ProjectileView _view;

        public float Damage { get => _damage; set => _damage = value; }
        public ProjectileView View { get => _view;}

        public Transform Transform { get => _transform; set => _transform = value; }
        public Rigidbody2D Rgdbody { get => _rgdbody; set => _rgdbody = value; }

        private Action<ProjectileModel> _onDestroy;

        public ProjectileModel(float damage, ProjectileView view, Action<ProjectileModel> onDestroy) 
        {
            _transform = view.Transform;
            _rgdbody = view.Rigidbody;

            _damage = damage;
            _view = view;
            _view.OnLevelObjectContact += OnLevelObjectContact;
            _view.onEndLifeTime += OnEndLifeTime;
            _onDestroy = onDestroy;
        }

        private void OnLevelObjectContact(LevelObjectView levelObject) 
        {
            if (levelObject.gameObject.tag == "Player") 
            {
                _onDestroy?.Invoke(this);
            }
        }

        private void OnEndLifeTime() => _onDestroy?.Invoke(this);

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnLevelObjectContact;
            _view.onEndLifeTime -= OnEndLifeTime;
            _onDestroy = null;
        }
    }
}
