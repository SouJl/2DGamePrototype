using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model
{
    public class ProjectileWeponModel : AbstractWeaponModel
    {
        private Transform _muzzle;
        private LevelObjectView _projectile;

        private float _shootPower;
        private ForceMode2D _forceMode;
        
        public float ShootPower { get => _shootPower; set => _shootPower = value; }
        public ForceMode2D ForceMode { get => _forceMode; set => _forceMode = value; }

        public ProjectileWeponModel(float damage, float attackDelay, Transform muzzle, LevelObjectView projectile, float shootPower, ForceMode2D forceMode) : base(damage, attackDelay)
        {
            _muzzle = muzzle;
            _projectile = projectile;
            _shootPower = shootPower;
            _forceMode = forceMode;
        }

        public override void Attack()
        {
            var prjOb = Object.Instantiate(_projectile, _muzzle.position, _muzzle.rotation);
            var rgb = prjOb.Rigidbody;
            rgb.AddForce(_muzzle.up * _shootPower, _forceMode);
        }
    }
}
