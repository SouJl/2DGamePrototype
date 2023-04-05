using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyView
    {
        void Init(IEnemyController controller);
    }

    internal class EnemyView : MonoBehaviour, IEnemyView
    {
        private IEnemyController _controller;

        public void Init(IEnemyController controller)
        {
            _controller = controller;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _controller.OnCollisionContact(collision);
        }
    }
}
