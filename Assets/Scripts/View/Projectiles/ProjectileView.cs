using UnityEngine;

namespace PixelGame.View
{
    public class ProjectileView : LevelObjectView
    {
        private TrailRenderer _trailRenderer;

        public override void Awake()
        {
            base.Awake();
            if (TryGetComponent(out TrailRenderer trail))
            {
                _trailRenderer = trail;
            }
        }

        public override void SetActive(bool state)
        {
            base.SetActive(state);
            
            if(state == false)
                _trailRenderer?.Clear();
        }
    }
}

