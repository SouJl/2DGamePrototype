using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class PatrolEnemyModel : BaseEnemyModel
    {
        public PatrolEnemyModel(Transform selfTransform, IEnemyData data) : base(selfTransform, data)
        {
        }

        public override event Action OnHealthEnd;

        public override void Damage(float amount)
        {
            Health -= amount;
            Debug.Log($"Current {nameof(PatrolEnemyModel)} Healt = {Health}");

            if (Health <= 0)
                OnHealthEnd?.Invoke();
        }
    }
}
