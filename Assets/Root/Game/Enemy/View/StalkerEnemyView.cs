using Root.PixelGame.Game.AI.ViewComponent;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class StalkerEnemyView : EnemyView
    {
        [SerializeField] private SeekerAIViewComponent _aIViewComponent;

        public IAIViewComponent AIViewComponent => _aIViewComponent;


        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }

    }
}
