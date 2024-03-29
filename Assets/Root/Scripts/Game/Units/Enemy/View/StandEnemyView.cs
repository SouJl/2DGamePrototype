﻿using PixelGame.Game.Weapon;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    internal class StandEnemyView : EnemyView
    {
        [SerializeField] private EnemyDataConfig _data;
        [SerializeField] private WeaponView _weapon;

        public IEnemyData Data => _data;
        public IWeaponView Weapon => _weapon;

        public override void Init(IEnemyController controller)
        {
            base.Init(controller);
        }
    }
}
