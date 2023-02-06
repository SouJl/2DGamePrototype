using UnityEngine;

namespace PixelGame.View
{
    [RequireComponent(typeof(Collider2D))]
    public class InteractQuestView:QuestObjectView
    {
        [SerializeField] private Sprite _disableState;
        [SerializeField] private Sprite[] _activeState; 
        [SerializeField] private Collider2D _collider2D;

        [SerializeField] private float _animDelay = 2f;

        private float _lastUpdateTime;
        private int _currentAnim = 0;
        
        private bool _isActive;

        public override void Awake()
        {
            base.Awake();
        }


        private void Update()
        {
            if (!_isActive) return;

            if (_lastUpdateTime > _animDelay)
            {
                _currentAnim = (_currentAnim + 1) % _activeState.Length;
                SpriteRenderer.sprite = _activeState[_currentAnim];
                _lastUpdateTime = 0;
            }
            else
            {
                _lastUpdateTime += Time.deltaTime;
            }
        }

        private void OnValidate()
        {
            _collider2D ??= GetComponent<Collider2D>();
        }

        public override void ProcessActivate()
        {
            base.ProcessActivate();
            _isActive = false;
            SpriteRenderer.sprite = _disableState;
        }

        public override void ProcessComplete()
        {
            base.ProcessComplete();
            _isActive = true;
        }

        protected override void CollisionStay(Collider2D collision)
        {
            base.CollisionStay(collision);
            if (collision.TryGetComponent(out LevelObjectView collideObject))
            {
                OnLevelObjectContact?.Invoke(collideObject);
            }
        }
    }
}
