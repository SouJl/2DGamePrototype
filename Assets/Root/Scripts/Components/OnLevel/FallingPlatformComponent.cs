using UnityEngine;
using System.Collections;

namespace Assets.PixelGame.Components.OnLevel
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal class FallingPlatformComponent : MonoBehaviour
    {
        [SerializeField] private float _fallingDelay = 1f;
        [SerializeField] private float _destroyDelay = 3f;

        [SerializeField] private bool _isShakeAcive = true;
        [SerializeField] private float _timeBetweenCallShake = 1f;
        [SerializeField] private ShakeComponent[] _shakeComponents;

        private float _lastShakeTime = 0f;

        private Rigidbody2D _rigidbody;
  

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
            _lastShakeTime = _timeBetweenCallShake;
        }

        private void Update()
        {
            if (_isShakeAcive)
            {
                if (_lastShakeTime > _timeBetweenCallShake)
                {
                    foreach (var shakeComponent in _shakeComponents)
                    {
                        shakeComponent.Begin();
                    }
                    _lastShakeTime = 0;
                }
                else
                {
                    _lastShakeTime += Time.deltaTime;
                }
            }        
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                StartCoroutine(Falling());
            }
        }

        IEnumerator Falling()
        {
            _isShakeAcive = false;
            foreach (var shakeComponent in _shakeComponents)
            {
                shakeComponent.End();
            }
            yield return new WaitForSeconds(_fallingDelay); 
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            Destroy(gameObject, _destroyDelay);
        }
    }
}
