using System;
using UnityEngine;

namespace PixelGame.View
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelObjectTrigger : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        public Action<LevelObjectView> TriggerEnter;
        public Action<LevelObjectView> TriggerExit;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var _levlObj = other.GetComponent<LevelObjectView>();

            if (!_levlObj)
                TriggerEnter?.Invoke(_levlObj);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var _levlObj = other.GetComponent<LevelObjectView>();

            if (!_levlObj)
                TriggerExit?.Invoke(_levlObj);
        }
    }
}
