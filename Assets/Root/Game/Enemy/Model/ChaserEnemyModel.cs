using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class ChaserEnemyModel : BaseEnemyModel
    {
        public ChaserEnemyModel(IEnemyView view, IEnemyData data) : base(view, data)
        {
        }

        public override void TakeDamage(float amount)
        {
            this.Health -= amount;
            Debug.Log($"Current {nameof(ChaserEnemyModel)} Healt = {Health}");

            if (Health <= 0) 
            {
                _view.ChangeLevelDisplay(false);
            }
        }
    }
}
