using UnityEngine;

namespace PixelGame.View
{
    public class PickUpQuestView : QuestObjectView
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private float _animDelay = 2f;

        private float _lastUpdateTime;
        private int _currentAnim = 0;

        public override void Awake()
        {
            base.Awake();

            SpriteRenderer.sprite = _sprites[_currentAnim];
            _lastUpdateTime = 0;


        }

        private void Update()
        {
            if(_lastUpdateTime > _animDelay) 
            {
                _currentAnim = (_currentAnim + 1) % _sprites.Length;
                SpriteRenderer.sprite = _sprites[_currentAnim];
                _lastUpdateTime = 0;
            }
            else 
            {
                _lastUpdateTime += Time.deltaTime;
            }
        }

        public override void ProcessComplete()
        {
            base.ProcessComplete();

            gameObject.SetActive(false);
        }

        public override void ProcessActivate()
        {
            base.ProcessActivate();

            gameObject.SetActive(true);
        }
    }
}
