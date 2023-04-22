using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class ChaserEnemyModel : BaseEnemyModel
    {

        public override event Action OnHealthEnd;

        public ChaserEnemyModel(Transform selfTransform, IEnemyData data) : base(selfTransform, data)
        {
        }

   

        public override void Damage(float amount)
        {
            this.Health -= amount;
            Debug.Log($"Current {nameof(ChaserEnemyModel)} Healt = {Health}");

            if (Health <= 0)
                OnHealthEnd?.Invoke();
        }
    }
}
