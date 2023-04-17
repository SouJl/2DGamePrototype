using Assets.Root.Components;
using Root.PixelGame.Components.Core;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyView
    {
        IEnemyCoreComponent EnemyCoreView { get; }
        void Init(IEnemyController controller);
    }

    internal abstract class EnemyView : MonoBehaviour, IEnemyView
    {
        private IEnemyController _controller;

        [SerializeField] private AnimationViewComponent _animation; 

        public AnimationViewComponent Animation => _animation;
        public abstract IEnemyCoreComponent EnemyCoreView { get; }

        public virtual void Init(IEnemyController controller)
        {
            _controller = controller;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _controller.OnCollisionContact(collision);
        } 
    }
}
