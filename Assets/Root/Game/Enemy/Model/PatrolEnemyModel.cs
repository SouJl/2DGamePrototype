using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class PatrolEnemyModel : BaseEnemyModel
    {
        public PatrolEnemyModel(IEnemyView view, IEnemyData data) : base(view, data)
        {
        }

        public override void TakeDamage(float amount)
        {
            Health -= amount;
            Debug.Log($"Current {nameof(PatrolEnemyModel)} Healt = {Health}");

            if (Health <= 0)
            {
                _view.ChangeLevelDisplay(false);
            }
        }
    }
}
