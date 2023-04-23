using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class StandEnemyModel : BaseEnemyModel
    {
        public StandEnemyModel(IEnemyView view, IEnemyData data) : base(view, data)
        {
        }

        public override void TakeDamage(float amount)
        {
            Health -= amount;
            Debug.Log($"Current {nameof(StandEnemyModel)} Healt = {Health}");

            if (Health <= 0)
            {
                _view.ChangeLevelDisplay(false);
            }
        }
    }
}
