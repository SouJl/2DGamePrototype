using PixelGame.Components;
using PixelGame.Configs;
using UnityEngine;

namespace PixelGame.View
{
    public class BatEnemyView : EnemyView
    {
        
        [Header("BatEnemy Settings")]
        [SerializeField] private ProjectileWeaponView _weapon;

        public ProjectileWeaponView Weapon { get => _weapon; }

        public override void Awake()
        {
            base.Awake();
        }
    }
}
