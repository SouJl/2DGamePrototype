using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class ProtectorEnemyModel : BaseEnemyModel
    {
        public ProtectorEnemyModel(IEnemyView view, IEnemyData data) : base(view, data)
        {
        }

        public override void TakeDamage(float amount)
        {
            Health -= amount;
            Debug.Log($"Current {nameof(ProtectorEnemyModel)} Healt = {Health}");


            if (Health <= 0)
            {
                _view.ChangeLevelDisplay(false);
            }
        }
    }
}
