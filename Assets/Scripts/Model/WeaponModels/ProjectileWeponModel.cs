using PixelGame.Controllers;
using UnityEngine;

namespace PixelGame.Model
{
    public class ProjectileWeponModel : AbstractWeaponModel
    {
        private Transform _muzzle;

        private float _shootPower;
        private ForceMode2D _forceMode;
        
        public float ShootPower { get => _shootPower; set => _shootPower = value; }
        public ForceMode2D ForceMode { get => _forceMode; set => _forceMode = value; }

        private float _lastAtackTime;

        private ProjectilesController _projectilesController;

        public ProjectileWeponModel(float damage, float attackDelay, Transform muzzle, float shootPower, ForceMode2D forceMode, ProjectilesController controller) : base(damage, attackDelay)
        {
            _muzzle = muzzle;
            _shootPower = shootPower;
            _forceMode = forceMode;

            _projectilesController = controller;
        }
        
        private bool CanAttack() => Time.time - _lastAtackTime >= AttackDelay;

        public override void Attack(Vector3 target)
        {
            if (!CanAttack()) return;

            var flipVector = new Vector3(0, 180, 0);
            var dir = target - _muzzle.position;
            var angle = Vector3.Angle(Vector3.right + flipVector, dir);
            var axis = Vector3.Cross(Vector3.right + flipVector, dir);
            _muzzle.rotation = Quaternion.AngleAxis(angle, axis);

            var prjmodel = _projectilesController.Add(Damage);
            prjmodel.Rgdbody.AddForce(_muzzle.up * _shootPower, _forceMode);
            _lastAtackTime = Time.time;
        }
     
        public override void Update(float time)
        {
            _projectilesController.Update(time);
        }
    }
}
