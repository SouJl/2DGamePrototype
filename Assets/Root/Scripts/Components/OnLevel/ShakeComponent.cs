using System.Collections;
using UnityEngine;

namespace Assets.PixelGame.Components.OnLevel
{
    internal class ShakeComponent : MonoBehaviour
    {
        [Header("Settings")]
        [Range(0f, 2f)]
        [SerializeField] private float _time = 0.2f;
        [Range(0f, 2f)]
        [SerializeField] private float _distance = 0.1f;
        [Range(0f, 0.1f)]
        [SerializeField] private float _delayBetweenShakes = 0f;

        private Vector3 _startPos;
        private float _timer;
        private Vector3 _randomPos;

        private void Awake()
        {
            _startPos = transform.position;
        }

  
        public void Begin()
        {
            StopAllCoroutines();
            StartCoroutine(Shake());
        }

        private IEnumerator Shake()
        {
            _timer = 0f;

            while (_timer < _time)
            {
                _timer += Time.deltaTime;

                _randomPos = _startPos + (Random.insideUnitSphere * _distance);

                transform.position = _randomPos;

                if (_delayBetweenShakes > 0f)
                {
                    yield return new WaitForSeconds(_delayBetweenShakes);
                }
                else
                {
                    yield return null;
                }    
            }

            transform.position = _startPos;
        }

        public void End()
        {
            StopAllCoroutines();
            transform.position = _startPos;
        }
    }
}
