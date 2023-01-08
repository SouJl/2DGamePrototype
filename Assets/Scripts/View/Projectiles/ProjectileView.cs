using System;
using System.Collections;
using UnityEngine;

namespace PixelGame.View
{
    public class ProjectileView : LevelObjectView
    {
        [SerializeField] private float _lifeTime = 3f;

        public Action onEndLifeTime;

        public override void Awake()
        {
            base.Awake();
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

