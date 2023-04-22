using Assets.Root.Components;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyView
    {
        void ChangeLevelDisplay(bool state);

        void Init(IEnemyController controller);
    }

    internal abstract class EnemyView : MonoBehaviour, IEnemyView
    {
        private IEnemyController _controller;

        [SerializeField] private AnimationViewComponent _animation; 

        public AnimationViewComponent Animation => _animation;

        public void ChangeLevelDisplay(bool state)
        {
            gameObject.SetActive(state);
        }

        public virtual void Init(IEnemyController controller)
        {
            _controller = controller;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_controller == null) return;

            _controller.OnCollisionContact(collision);
        } 
    }
}
