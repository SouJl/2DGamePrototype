using PixelGame.Enumerators;
using PixelGame.Model.Utils;
using PixelGame.View;
using System.Collections.Generic;
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

        private List<ProjectileModel> _projectiles;

        private ViewService _projectileViewService;

        public ProjectileWeponModel(float damage, float attackDelay, Transform muzzle, float shootPower, ForceMode2D forceMode, ProjectileType projectileType) : base(damage, attackDelay)
        {
            _muzzle = muzzle;
            _shootPower = shootPower;
            _forceMode = forceMode;
            
            _projectiles = new List<ProjectileModel>();

            _projectile = Resources.Load<LevelObjectView>($"{projectileType}Projectile");
            
            if (!_projectile) 
            {
                Debug.LogError($"Can't find Resource {projectileType}Projectile");
            }

            _projectileViewService = new ViewService(_muzzle);
        }

        public override void Attack()
        {
            var prjOb = _projectileViewService.Instantiate<LevelObjectView>(_projectile);
            prjOb.transform.position = _muzzle.position;
            prjOb.transform.rotation = _muzzle.rotation;

            _projectiles.Add(new ProjectileModel(Damage, prjOb.GetComponent<ProjectileView>(), OnDestroyProjectile));
            
            var rgb = prjOb.Rigidbody;
            
            rgb.AddForce(_muzzle.up * _shootPower, _forceMode);
        }

        private void OnDestroyProjectile(ProjectileModel projectile) 
        {
            _projectiles.Remove(projectile);
            _projectileViewService.Destroy(projectile.View);
            projectile.Dispose();
        }
    }
}
