using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class EnemyControllerFactory
    {

        private Transform _playerTransform;

        public EnemyControllerFactory(Transform playerTransform) 
        {
            _playerTransform = playerTransform;
        }

        public IExecute GetEnemyController(EnemyView enemy) 
        {
            switch(enemy)
            {
                default:
                    return null;

                case BatEnemyView batEnemy: 
                    {
                        var weaponView = batEnemy.Weapon;
                        var weapon = new ProjectileWeponModel(weaponView.Damage, weaponView.AttackDelay, weaponView.Muzzle, weaponView.ShootPower, weaponView.ForceMode, weaponView.ProjectileType);
                        var enemyModel = new BatEnemyModel(_playerTransform, batEnemy.SpriteRenderer, batEnemy.Collider, new NoneMoveModel(), weapon, weaponView.Muzzle);
                        return new BatEnemyController(batEnemy, enemyModel);
                    }
            }
        }
    }
}
