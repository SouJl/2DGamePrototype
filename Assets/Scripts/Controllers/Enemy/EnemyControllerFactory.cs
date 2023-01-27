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

                case StalkerEnemyView batEnemy: 
                    {
                        var weaponView = batEnemy.Weapon;             
                        var components = new ComponentsModel(batEnemy.Transform, batEnemy.Rigidbody, batEnemy.Collider);
                        
                        var projController = new ProjectilesController(weaponView.ProjectileType, weaponView.ProjectileLifeTime, _enemyViewSevice);
                        var weapon = new ProjectileWeponModel(weaponView.Damage, weaponView.AttackDelay, weaponView.Muzzle, weaponView.ShootPower, weaponView.ForceMode, projController);

                        var ai = new StalkerAI(batEnemy.AIConfig, components, batEnemy.Seeker, _playerTransform);                        
                        var enemyModel = new StandartEnemyModel(components, batEnemy.SpriteRenderer, ai, batEnemy.Speed, batEnemy.MoveThresh);
                        
                        return new StalkerEnemyController(_playerTransform, batEnemy, enemyModel, weapon);
                    }
                    case ProtectorEnemyView wizardEnemy: 
                    {
                        var components = new ComponentsModel(wizardEnemy.Transform, wizardEnemy.Rigidbody, wizardEnemy.Collider);
                        var ai = new ProtectorAI(wizardEnemy.AIConfig, components, wizardEnemy.Seeker, wizardEnemy.ProtectedZone, _playerTransform.tag);
                        var enemyModel = new StandartEnemyModel(components, wizardEnemy.SpriteRenderer, ai, wizardEnemy.Speed, wizardEnemy.MoveThresh);
                        return new ProtectorEnemyController(wizardEnemy, enemyModel);
                    }
                case ChaserEnemyView chaserEnemy:
                    {
                        return new ChaserEnemyController(chaserEnemy, _playerTransform);
                    }
            }
        }
    }
}
