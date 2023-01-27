using Pathfinding;
using PixelGame.Components;
using UnityEngine;

namespace PixelGame.View
{
    public class StalkerEnemyView : EnemyView
    {
        [Header("StalkerEnemy Settings")]
        [SerializeField] private LocatorComponent _locator;
        [SerializeField] private ProjectileWeaponView _weapon;
        [SerializeField] private Seeker _seeker;

        public LocatorComponent Locator { get => _locator; }
        public ProjectileWeaponView Weapon { get => _weapon; }
        public Seeker Seeker { get => _seeker; }

        public override void Awake()
        {
            base.Awake();
            _seeker = GetComponent<Seeker>();
        }
    }
}
