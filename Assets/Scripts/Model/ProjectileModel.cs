using System;
using PixelGame.View;

namespace PixelGame.Model
{
    public class ProjectileModel : IDisposable
    {
        private float _damage;
        private ProjectileView _view;

        public float Damage { get => _damage; set => _damage = value; }
        public LevelObjectView View { get => _view;}

        private Action<ProjectileModel> _onDestoy;

        public ProjectileModel(float damage, ProjectileView view, Action<ProjectileModel> onDestroy) 
        {
            _damage = damage;
            _view = view;
            _view.OnLevelObjectContact += OnLevelObjectContact;
            _view.onEndLifeTime += OnEndLifeTime;
            _onDestoy = onDestroy;
        }

        private void OnLevelObjectContact(LevelObjectView levelObject) 
        {
            if (levelObject.gameObject.tag == "Player") 
            {
                _onDestoy?.Invoke(this);
            }
        }

        private void OnEndLifeTime() => _onDestoy?.Invoke(this);

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnLevelObjectContact;
            _view.onEndLifeTime -= OnEndLifeTime;
            _onDestoy = null;
        }
    }
}
