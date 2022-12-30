﻿using PixelGame.Enumerators;
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

        public ProjectileWeponModel(float damage, float attackDelay, Transform muzzle, float shootPower, ForceMode2D forceMode, ProjectileType projectileType) : base(damage, attackDelay)
        {
            _muzzle = muzzle;
            _shootPower = shootPower;
            _forceMode = forceMode;

            _projectile = Resources.Load<LevelObjectView>($"{projectileType}Projectile");
            if (!_projectile) 
            {
                Debug.LogError($"Can't find Resource {projectileType}Projectile");
            }
        }

        public override void Attack()
        {
            var prjOb = Object.Instantiate(_projectile, _muzzle.position, _muzzle.rotation);
            var rgb = prjOb.Rigidbody;
            rgb.AddForce(_muzzle.up * _shootPower, _forceMode);
        }
    }
}