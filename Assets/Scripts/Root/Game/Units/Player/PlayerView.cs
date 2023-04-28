using Root.PixelGame.Game.Core;
using Root.PixelGame.Game.Weapon;
using UnityEngine;

namespace Root.PixelGame.Game
{
    internal interface IPlayerView
    {
        public Transform Transform { get; }
        public SpriteRenderer SpriteRenderer { get; }
        public Collider2D Collider { get; }
        public Rigidbody2D Rigidbody { get; }

        public Transform GroundCheck { get; }
        public Transform WallCheck { get; }
        public Transform LedgeCheck { get; }

        void Init(IPlayerController playerController);
    }

    internal class PlayerView : UnitView, IPlayerView
    {
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
        [field: SerializeField] public Collider2D Collider { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }

        [field: SerializeField] public Transform GroundCheck { get; private set; }
        [field: SerializeField] public Transform WallCheck { get; private set; }
        [field: SerializeField] public Transform LedgeCheck { get; private set; }

        [field : SerializeField] public WeaponView Weapon { get; private set; }

        private IPlayerController _playerController;

        private void OnValidate()
        {
            Transform = GetComponent<Transform>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Collider = GetComponent<Collider2D>();
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Init(IPlayerController playerController)
        {
            _playerController = playerController;
        }

        public override void Damage(float amount)
        {
            if (_playerController == null) return;

            _playerController.Damage(amount);
        }
        public override void Knockback(Vector2 angle, float strength, int direction)
        {
            if (_playerController == null) return;

            _playerController.Knockback(angle, strength, direction);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _playerController.OnLevelContact(collision);
        }

       
    }
}
