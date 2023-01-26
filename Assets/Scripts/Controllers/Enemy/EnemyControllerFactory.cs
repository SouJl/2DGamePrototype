using PixelGame.Configs;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.Model.AIModels;
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
                        var pathfinding = new PathfinderModel(Resources.Load<AIConfig>("StalkerAIConfig"));
                        var ai = new StalkerAI(components, pathfinding, batEnemy.Seeker, _playerTransform);
                        var enemyModel = new StandartAIEnemyModel(components, batEnemy.SpriteRenderer, ai, batEnemy.Speed);
                        return new BatEnemyController(_playerTransform, batEnemy, enemyModel, weapon);
                    }
                    case WizzardEnemyView wizardEnemy: 
                    {
                        var components = new ComponentsModel(wizardEnemy.Transform, wizardEnemy.Rigidbody, wizardEnemy.Collider);
                        var pathfinding = new PathfinderModel(Resources.Load<AIConfig>("PatrolAIConfig"));
                        var protectorModel = new ProtectorModel(components, new PatrolModel(wizardEnemy.WayPoints));
                        var protectinZone = new ProtectedZoneModel(wizardEnemy.ProtectedZone, protectorModel);
                        var ai = new ProtectorAI(components, pathfinding,protectorModel, wizardEnemy.Seeker);
                        var enemyModel = new StandartAIEnemyModel(components, wizardEnemy.SpriteRenderer, ai, wizardEnemy.Speed);
                        return new WizardController(wizardEnemy, enemyModel,protectinZone);
                    }
            }
        }
    }
}
