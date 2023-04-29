using System;
using UnityEngine;

namespace PixelGame.Components
{
    internal interface ILevelObjectTrigger
    {
        event Action<Collider2D> TriggerEnter;
        event Action<Collider2D> TriggerExit;
        event Action<Collider2D> TriggerStay;
    }

    [RequireComponent(typeof(Collider2D))]
    internal class LevelObjecTriggerComponent : MonoBehaviour, ILevelObjectTrigger
    {
        [SerializeField] private Collider2D _collider;

        public event Action<Collider2D> TriggerEnter;
        public event Action<Collider2D> TriggerExit;
        public event Action<Collider2D> TriggerStay;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var _levlObj = collision.GetComponent<Collider2D>();

            if (_levlObj)
                TriggerEnter?.Invoke(_levlObj);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            var _levlObj = collision.GetComponent<Collider2D>();

            if (_levlObj)
                TriggerExit?.Invoke(_levlObj);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            var _levlObj = collision.GetComponent<Collider2D>();

            if (_levlObj)
                TriggerStay?.Invoke(_levlObj);
        }
    }
}
