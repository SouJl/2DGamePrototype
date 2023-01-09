using PixelGame.Configs;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.View
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] private float _points = 10f;
        [SerializeField] private List<Transform> _coinsPosition;

        [SerializeField] private AnimationConfig _animationConfig;
        [SerializeField] private float _animationSpeed = 10f;


        public float Points { get => _points; }
        public AnimationConfig AnimationConfig { get => _animationConfig; }
        public float AnimationSpeed { get => _animationSpeed; }
        public List<Transform> CoinsPosition { get => _coinsPosition;}
    }
}
