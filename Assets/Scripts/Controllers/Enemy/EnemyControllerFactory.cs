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

        private ViewService _enemyViewSevice;

        public EnemyControllerFactory(Transform playerTransform, ViewService viewService) 
        {
            _playerTransform = playerTransform;
            _enemyViewSevice = viewService;
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
                        var projController = new ProjectilesController(weaponView.ProjectileType, weaponView.ProjectileLifeTime, _enemyViewSevice);
                        var components = new ComponentsModel(batEnemy.Transform, batEnemy.Rigidbody, batEnemy.Collider);
                        var weapon = new ProjectileWeponModel(weaponView.Damage, weaponView.AttackDelay, weaponView.Muzzle, weaponView.ShootPower, weaponView.ForceMode, projController);
                        var ai = new StalkerAI(Resources.Load<AIConfig>("StalkerAIConfig"));
                        var enemyModel = new StalkerEnemyModel(components, batEnemy.SpriteRenderer, ai, batEnemy.Seeker, batEnemy.Speed);
                        return new BatEnemyController(_playerTransform, batEnemy, enemyModel, weapon);
                    }
                case WizzardEnemyView wizardEnemy: 
                    {
                        var components = new ComponentsModel(wizardEnemy.Transform, wizardEnemy.Rigidbody, wizardEnemy.Collider);
                        var ai = new PatrolAI(Resources.Load<AIConfig>("PatrolAIConfig"), wizardEnemy.WayPoints);
                        var enemyModel = new PatrolEnemyModel(components, wizardEnemy.SpriteRenderer, ai);
                        return new WizardController(_playerTransform, wizardEnemy, enemyModel);
                    }
            }
        }
    }
}
