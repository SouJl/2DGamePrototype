using UnityEngine;

namespace Root.PixelGame.Game
{
    internal interface IPlayerView
    {
        public Transform Transform { get; }
        public SpriteRenderer SpriteRenderer { get; }
        public Collider2D Collider { get; }
        public Rigidbody2D Rigidbody { get; }
    }

    internal class PlayerView : MonoBehaviour, IPlayerView
    {
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
        [field: SerializeField] public Collider2D Collider { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    }
}
