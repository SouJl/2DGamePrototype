﻿
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal class ChaserEnemyModel : BaseEnemyModel
    {
        public ChaserEnemyModel(
            Transform transform,
            IEnemyData data) : base(transform, data)
        {
        }
    }
}
