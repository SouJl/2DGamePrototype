using System;
using UnityEngine;

namespace PixelGame.Components
{
    internal class ParallaxComponent : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [Range(0, 1)]
        [SerializeField] private float _parallaxEffect = 0f;

        private float _width;
        private float _startHorizontalPos;

        private void Start()
        {
            _startHorizontalPos = transform.position.x;
            _width = GetComponent<SpriteRenderer>().bounds.size.x;
        }


        private void FixedUpdate()
        {
            float cameraPosX = _mainCamera.transform.position.x;

            float temp = cameraPosX * (1 - _parallaxEffect);
            float distance = cameraPosX * _parallaxEffect;

            transform.position = new Vector3(_startHorizontalPos + distance, transform.position.y);

            if (temp > _startHorizontalPos + _width) _startHorizontalPos += _width;
            else if (temp < _startHorizontalPos - _width) _startHorizontalPos -= _width;
        }
    }
}
