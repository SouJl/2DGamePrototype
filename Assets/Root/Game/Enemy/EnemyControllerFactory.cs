using Root.PixelGame.Tool;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyControllerFactory
    {
        IEnemyController CreateEnemyController(IEnemyView view);
    }

    internal class EnemyControllerFactory : IEnemyControllerFactory
    {
        private readonly string StalkerEnemyDataPath = @"Enemy/PursuerEnemyData";
        private readonly string PatrolEnemyDataPath = @"Enemy/PatrolEnemyData";
        private readonly string ChaserEnemyDataPath = @"Enemy/ChaserEnemyData";
        private readonly string ProtectorEnemyDataPath = @"Enemy/ProtectorEnemyData";

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
                        IEnemyModel model = new PursuerEnemyModel(pursuerEnemy.transform, data);                       
                        ITargetSelector targetSelector = new ManualTargetSelector(playerTransform); 
                        
                        return new PursuerEnemyController(pursuerEnemy, data, model, targetSelector);
                    }
                case ChaserEnemyView chaserEnemy: 
                    {
                        IEnemyData data = LoadData(ChaserEnemyDataPath);
                        IEnemyModel model = new ChaserEnemyModel(chaserEnemy.transform, data);                       
                        ITargetSelector targetSelector = new DynamicTargetSelector();
                        
                        return new ChaserEnemyController(chaserEnemy, data, model, targetSelector, chaserEnemy.TargetLocator, chaserEnemy.ChaseBreakDistance);
                    }
                case PatrolEnemyView patrolEnemy:
                    {
                        IEnemyData data = LoadData(PatrolEnemyDataPath);
                        IEnemyModel model = new PatrolEnemyModel(patrolEnemy.transform, data);
                        ITargetSelector targetSelector = new DynamicTargetSelector();

                        return new PatrolEnemyController(patrolEnemy, data, model, targetSelector);
                    }
                case ProtectorEnemyView protectorEnemy: 
                    {
                        IEnemyData data = LoadData(ProtectorEnemyDataPath);
                        IEnemyModel model = new ProtectorEnemyModel(protectorEnemy.transform, data);
                        ITargetSelector targetSelector = new DynamicTargetSelector();

                        return new ProtectorEnemyController(protectorEnemy, data, model, targetSelector, protectorEnemy.ProtectionZone);
                    }

                case StandEnemyView standEnemy: 
                    {
                        IEnemyData data = standEnemy.Data;
                        IEnemyModel model = new StandEnemyModel(standEnemy.transform, data);
                        return new StandEnemyController(standEnemy, data, model);
                    }
            }
        }

        private IEnemyData LoadData(string path) 
            => ResourceLoader.LoadObject<EnemyDataConfig>(path);
    }
}
