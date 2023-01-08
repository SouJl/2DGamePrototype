using System;
using PixelGame.View;
using Object = UnityEngine.Object;

namespace PixelGame.Model
{
    public class ProjectileModel : IDisposable
    {
        private float _damage;
        private LevelObjectView _view;

        public float Damage { get => _damage; set => _damage = value; }
        public LevelObjectView View { get => _view;}

        private Action<ProjectileModel> _onDestoy;

        public ProjectileModel(float damage, LevelObjectView view, Action<ProjectileModel> onDestroy) 
        {
            _damage = damage;
            _view = view;
            View.OnLevelObjectContact += OnLevelObjectContact;
            _onDestoy = onDestroy;
        }

        private void OnLevelObjectContact(LevelObjectView levelObject) 
        {
            if (levelObject.gameObject.tag == "Player") 
            {
                _onDestoy?.Invoke(this);
            }
        }


        public void Dispose()
        {
            View.OnLevelObjectContact -= OnLevelObjectContact;
            _onDestoy = null;
        }
    }
}
