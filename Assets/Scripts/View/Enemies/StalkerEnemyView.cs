using Pathfinding;
using UnityEngine;

namespace PixelGame.View
{
    public class StalkerEnemyView : EnemyView
    {
        
        [Header("BatEnemy Settings")]
        [SerializeField] private ProjectileWeaponView _weapon;

        [SerializeField] private Seeker _seeker;

        public ProjectileWeaponView Weapon { get => _weapon; }
        public Seeker Seeker { get => _seeker; }

        public override void Awake()
        {
            base.Awake();
            _seeker = GetComponent<Seeker>();
        }
    }
}
