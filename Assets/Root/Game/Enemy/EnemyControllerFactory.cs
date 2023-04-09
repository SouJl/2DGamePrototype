using Root.PixelGame.Game.Core;
using Root.PixelGame.Tool;
using System;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyControllerFactory
    {
        IEnemyController CreateEnemyController(IEnemyView view);
    }

    internal class EnemyControllerFactory : IEnemyControllerFactory
    {
        private readonly string StalkerEnemyDataPath = @"Enemy/StalkerEnemyData";
        private readonly string PatrolEnemyDataPath = @"Enemy/PatrolEnemyData";

        public EnemyControllerFactory()
        {
        }

        public IEnemyController CreateEnemyController(IEnemyView view)
        {

            switch (view)
            {
                default:
                    return null;
                case StalkerEnemyView stalkerEnemy: 
                    {
                        IEnemyData data = LoadData(StalkerEnemyDataPath);
                        IEnemyModel model = new StalkerEnemyModel(data);
                        var coreFactory = new EnemyCoreFactory(data);
                        IEnemyCore core = coreFactory.GetEnemyCore(stalkerEnemy);
                        return new EnemyController(stalkerEnemy, model, core);
                    }
                case PatrolEnemyView patrolEnemy: 
                    {
                        IEnemyData data = LoadData(PatrolEnemyDataPath);
                        IEnemyModel model = new PatrolEnemyModel(data);
                        var coreFactory = new EnemyCoreFactory(data);
                        IEnemyCore core = coreFactory.GetEnemyCore(patrolEnemy);
                        return new EnemyController(patrolEnemy, model, core);
                    }
            }
        }


        private IEnemyData LoadData(string path) => ResourceLoader.LoadObject<EnemyDataConfig>(path);

    }
}
