using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class PursuerEnemyModel : BaseEnemyModel
    {
        public PursuerEnemyModel(IEnemyView view, IEnemyData data) : base(view, data)
        {
        }

        public override void TakeDamage(float amount)
        {
            Health -= amount;
            Debug.Log($"Current {nameof(PursuerEnemyModel)} Healt = {Health}");


            if (Health <= 0)
            {
                _view.ChangeLevelDisplay(false);
            }
        }
    }
}
