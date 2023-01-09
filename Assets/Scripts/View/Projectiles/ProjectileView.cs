using System;
using System.Collections;
using UnityEngine;

namespace PixelGame.View
{
    public class ProjectileView : LevelObjectView
    {
        [SerializeField] private float _lifeTime = 3f;

        public Action onEndLifeTime;
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

        public override void OnStartExecute()
        {
            base.OnStartExecute();
            StartCoroutine(LifeTimeCicle());
        }

        private IEnumerator LifeTimeCicle()
        {
            yield return new WaitForSeconds(_lifeTime);
            onEndLifeTime?.Invoke();
        }
    }
}

