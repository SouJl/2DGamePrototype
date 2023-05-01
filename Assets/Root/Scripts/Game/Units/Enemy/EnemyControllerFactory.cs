using PixelGame.Game.Weapon;
using PixelGame.Tool;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    internal interface IEnemyControllerFactory
    {
        IEnemyController CreateEnemyController(IEnemyView view);
    }

    internal class EnemyControllerFactory : IEnemyControllerFactory
    {
        private readonly string StalkerEnemyDataPath = @"Configs/Enemy/PursuerEnemyData";
        private readonly string PatrolEnemyDataPath = @"Configs/Enemy/PatrolEnemyData";
        private readonly string ChaserEnemyDataPath = @"Configs/Enemy/ChaserEnemyData";
        private readonly string ProtectorEnemyDataPath = @"Configs/Enemy/ProtectorEnemyData";
        private readonly string StrandingEnemyDataPath = @"Configs/Enemy/StrandingEnemyData";

        private readonly Transform playerTransform;

        public EnemyControllerFactory(Transform playerTransform) 
        {
            this.playerTransform = playerTransform;
        }

        public IEnemyController CreateEnemyController(IEnemyView view)
        {

            switch (view)
            {
                default:
                    return null;
                case PursuerEnemyView pursuerEnemy: 
                    {
                        IEnemyData data = LoadData(StalkerEnemyDataPath);
                        IEnemyModel model = new PursuerEnemyModel(pursuerEnemy.EnemyTransform, data);                       
                        ITargetSelector targetSelector = new ManualTargetSelector(playerTransform); 
                        
                        return new PursuerEnemyController(pursuerEnemy, data, model, targetSelector);
                    }
                case ChaserEnemyView chaserEnemy: 
                    {
                        IEnemyData data = LoadData(ChaserEnemyDataPath);
                        IEnemyModel model = new ChaserEnemyModel(chaserEnemy.EnemyTransform, data);                       
                        ITargetSelector targetSelector = new DynamicTargetSelector();
                        IWeapon weapon = new EnemyWeapon(chaserEnemy.Weapon);
                        return new ChaserEnemyController(chaserEnemy, data, model, weapon, targetSelector, chaserEnemy.TargetLocator, chaserEnemy.ChaseBreakDistance);
                    }
                case PatrolEnemyView patrolEnemy:
                    {
                        IEnemyData data = LoadData(PatrolEnemyDataPath);
                        IEnemyModel model = new PatrolEnemyModel(patrolEnemy.EnemyTransform, data);
                        ITargetSelector targetSelector = new DynamicTargetSelector();

                        return new PatrolEnemyController(patrolEnemy, data, model, targetSelector);
                    }
                case ProtectorEnemyView protectorEnemy: 
                    {
                        IEnemyData data = LoadData(ProtectorEnemyDataPath);
                        IEnemyModel model = new ProtectorEnemyModel(protectorEnemy.EnemyTransform, data);
                        ITargetSelector targetSelector = new DynamicTargetSelector();

                        return new ProtectorEnemyController(protectorEnemy, data, model, targetSelector, protectorEnemy.ProtectionZone);
                    }
                case StandEnemyView standEnemy: 
                    {
                        IEnemyData data = standEnemy.Data;
                        IEnemyModel model = new StandEnemyModel(standEnemy.EnemyTransform, data);
                        IWeapon weapon = new EnemyWeapon(standEnemy.Weapon);
                        return new StandEnemyController(standEnemy, data, model, weapon);
                    }
                case WanderEnemyView strandingEnemy: 
                    {
                        IEnemyData data = LoadData(StrandingEnemyDataPath);
                        IEnemyModel model = new StandEnemyModel(strandingEnemy.EnemyTransform, data);
                        IWeapon weapon = new EnemyWeapon(strandingEnemy.Weapon);
                        return new WanderEnemyController(strandingEnemy, data, model, weapon);
                    }
            }
        }

        private IEnemyData LoadData(string path) 
            => ResourceLoader.LoadObject<EnemyDataConfig>(path);
    }
}
