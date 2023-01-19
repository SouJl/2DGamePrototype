using PixelGame.Configs;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.Model.Utils;
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
                        var projController = new ProjectilesController(weaponView.ProjectileType, new ViewService(weaponView.Muzzle), weaponView.ProjectileLifeTime);
                        var weapon = new ProjectileWeponModel(weaponView.Damage, weaponView.AttackDelay, weaponView.Muzzle, weaponView.ShootPower, weaponView.ForceMode, projController);
                        var ai = new StalkerAI(batEnemy.Seeker, Resources.Load<AIConfig>("StalkerAIConfig"));
                        var move = new SimplePhysicsMove(batEnemy.Rigidbody, batEnemy.Speed, 0f);
                        var enemyModel = new BatEnemyModel(batEnemy.SpriteRenderer, batEnemy.Collider, move, ai, weaponView.Muzzle);
                        return new BatEnemyController(_playerTransform, batEnemy, enemyModel, weapon);
                    }
            }
        }
    }
}
