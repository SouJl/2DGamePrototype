using System;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model
{
    public class ProjectileModel : IDisposable
    {
        private Rigidbody2D _rgdbody;
        private float _damage;
        private ProjectileView _view;
        private float _lifeTime;

        public float Damage { get => _damage; set => _damage = value; }
        public ProjectileView View { get => _view;}

        public Rigidbody2D Rgdbody { get => _rgdbody; set => _rgdbody = value; }
        public float LifeTime { get => _lifeTime; set => _lifeTime = value; }

        private Action<ProjectileModel> _onDestroy;

        public ProjectileModel(float damage, ProjectileView view, Action<ProjectileModel> onDestroy) 
        {
            _rgdbody = view.Rigidbody;

            _damage = damage;
            _view = view;
            _view.OnLevelObjectContact += OnLevelObjectContact;
            _onDestroy = onDestroy;
            _lifeTime = 0;
        }

        private void OnLevelObjectContact(LevelObjectView levelObject) 
        {
            if (!levelObject) return;

            if (levelObject.gameObject.tag == "Player") 
            {
                _onDestroy?.Invoke(this);
            }
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnLevelObjectContact;
            _lifeTime = 0;
            _onDestroy = null;
        }
    }
}
