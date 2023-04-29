using PixelGame.Components.Core;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    [RequireComponent(typeof(PatrolAICoreComponent))]
    internal class PatrolEnemyView : EnemyView
    {
        [SerializeField] private PatrolAICoreComponent _coreComponent;

        public  IEnemyCoreComponent CoreComponent => _coreComponent;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }
        private void OnValidate()
        {
            _coreComponent = GetComponent<PatrolAICoreComponent>();
        }
    }
}
