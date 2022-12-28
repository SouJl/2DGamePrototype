using UnityEngine;

namespace PixelGame.View
{
    public class ProjectileWeaponView : WeaponView
    {
        [SerializeField] private float _shootPower = 10f;
        [SerializeField] private ForceMode2D _forceMode = ForceMode2D.Impulse;
        [SerializeField] private Transform _muzzle;
        [SerializeField] private LevelObjectView _projectile;

        public float ShootPower { get => _shootPower; }
        public ForceMode2D ForceMode { get => _forceMode; }
        public Transform Muzzle { get => _muzzle; }
        public LevelObjectView Projectile { get => _projectile; }
    }
}
