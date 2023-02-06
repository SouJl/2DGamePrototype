﻿using PixelGame.Configs;
using UnityEngine;

namespace PixelGame.View
{
    public class EnemyView:LevelObjectView
    {
        [Header("Enemy Settings")]
        [SerializeField] private EnemyData _enemyData;
      
        [Header("AI Settings")]
        [SerializeField] private AIConfig _aIConfig;

        public EnemyData EnemyData { get => _enemyData; }
        public AIConfig AIConfig { get => _aIConfig; }

        public override void Awake()
        {
            base.Awake();
        }

        protected override void CollisionContact(Collider2D collision)
        {
            base.CollisionContact(collision);
            if (collision.TryGetComponent(out LevelObjectView collideObject))
            {
                OnLevelObjectContact?.Invoke(collideObject);
            }
        }
    }
}
