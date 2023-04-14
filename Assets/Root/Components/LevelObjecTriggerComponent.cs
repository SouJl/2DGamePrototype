using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface ILevelObjectTrigger
    {
        event Action<Collider2D> TriggerEnter;
        event Action<Collider2D> TriggerExit;
    }

    [RequireComponent(typeof(Collider2D))]
    internal class LevelObjecTriggerComponent : MonoBehaviour, ILevelObjectTrigger
    {
        [SerializeField] private Collider2D _collider;

        public event Action<Collider2D> TriggerEnter;
        public event Action<Collider2D> TriggerExit;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var _levlObj = other.GetComponent<Collider2D>();

            if (_levlObj)
                TriggerEnter?.Invoke(_levlObj);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var _levlObj = other.GetComponent<Collider2D>();

            if (_levlObj)
                TriggerExit?.Invoke(_levlObj);
        }
    }
}
