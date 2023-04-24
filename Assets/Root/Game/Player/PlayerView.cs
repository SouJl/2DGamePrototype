using Root.PixelGame.Game.Core;
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
        void WeaponUsed();
    }

    internal class PlayerView : MonoBehaviour, IPlayerView, IDamageable
    {
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
        [field: SerializeField] public Collider2D Collider { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }

        [field: SerializeField] public Transform GroundCheck { get; private set; }
        [field: SerializeField] public Transform WallCheck { get; private set; }
        [field: SerializeField] public Transform LedgeCheck { get; private set; }

        [field : SerializeField] public GameObject Weapon { get; private set; }

        private IPlayerController _playerController;
        private bool _weponState;

        private void Awake()
        {
            _weponState = false;
            Weapon.SetActive(false);
        }

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

        public void Damage(float amount)
        {
            if (_playerController == null) return;

            _playerController.TakeDamage(amount);
        }

        public void WeaponUsed()
        {
            _weponState = !_weponState;

            Weapon.SetActive(_weponState);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _playerController.OnLevelContact(collision);
        }
    }
}
