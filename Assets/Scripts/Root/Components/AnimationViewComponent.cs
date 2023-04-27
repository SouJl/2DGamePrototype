using Root.PixelGame.Animation;
using UnityEngine;

namespace Assets.Root.Components
{
    [RequireComponent(typeof(SpriteRenderer))]
    internal class AnimationViewComponent : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private AnimationDataConfig _animationConfig;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public AnimationDataConfig AnimationConfig => _animationConfig;

        private void OnValidate()
        {
            _spriteRenderer ??= GetComponent<SpriteRenderer>();
        }
    }
}
