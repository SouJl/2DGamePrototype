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

                case StalkerEnemyView stalkerEnemy: 
                    {
                        var weaponView = stalkerEnemy.Weapon;             
                        var components = new ComponentsModel(stalkerEnemy.Transform, stalkerEnemy.Rigidbody, stalkerEnemy.Collider);
                        
                        var projController = new ProjectilesController(weaponView.ProjectileType, weaponView.ProjectileLifeTime, _enemyViewSevice);
                        var weapon = new ProjectileWeponModel(weaponView.Damage, weaponView.AttackDelay, weaponView.Muzzle, weaponView.ShootPower, weaponView.ForceMode, projController);

                        var ai = new StalkerAI(stalkerEnemy.AIConfig, components, stalkerEnemy.Seeker, _playerTransform);                        
                        var enemyModel = new StandartEnemyModel(components, stalkerEnemy.SpriteRenderer, ai, stalkerEnemy.EnemyData.speed, stalkerEnemy.EnemyData.moveThresh);
                        
                        return new StalkerEnemyController(_playerTransform, stalkerEnemy, enemyModel, weapon);
                    }
                    case ProtectorEnemyView protectorEnemy: 
                    {
                        var components = new ComponentsModel(protectorEnemy.Transform, protectorEnemy.Rigidbody, protectorEnemy.Collider);
                        var ai = new ProtectorAI(protectorEnemy.AIConfig, components, protectorEnemy.Seeker, protectorEnemy.ProtectedZone, protectorEnemy.SpeedMuliplier, _playerTransform.tag);
                        var enemyModel = new StandartEnemyModel(components, protectorEnemy.SpriteRenderer, ai, protectorEnemy.EnemyData.speed, protectorEnemy.EnemyData.moveThresh);
                        return new ProtectorEnemyController(protectorEnemy, enemyModel);
                    }
                case ChaserEnemyView chaserEnemy:
                    {
                        return new ChaserEnemyController(chaserEnemy, _playerTransform);
                    }
            }
        }
    }
}
