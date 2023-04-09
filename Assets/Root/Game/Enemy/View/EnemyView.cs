using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyView
    {
        void Init(IEnemyController controller);
    }

    [RequireComponent(typeof(Rigidbody2D))]
    internal class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private Transform _enemyTransform;
        [SerializeField] private Rigidbody2D _enemyRigidbody;

        private IEnemyController _controller;

        public Transform EnemyTransfrom => _enemyTransform;
        public Rigidbody2D EnemyRigidbody => _enemyRigidbody;
       
        public virtual void Init(IEnemyController controller)
        {
            _controller = controller;
        }

        private void OnValidate()
        {
            _enemyTransform = gameObject.transform;
            _enemyRigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _controller.OnCollisionContact(collision);
        }

 
    }
}
