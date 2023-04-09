using Root.PixelGame.Game.AI;
using Root.PixelGame.Game.Enemy;
using Root.PixelGame.Tool;

namespace Root.PixelGame.Game.Core
{ 
    internal class EnemyCoreFactory
    {
        private readonly string StalkerEnemyDataPath = @"Enemy/StalkerEnemyData";
        private readonly IAIFactory aIFactory;

        public EnemyCoreFactory() 
        {
            aIFactory = new AIFactory();
        }


        public IEnemyCore GetEnemyCore(IEnemyView view)
        {
            switch (view)
            {
                default:
                    return null;
                case StalkerEnemyView stalkerEnemy:
                    {
                        IPhysicModel physic = new PhysicModel(stalkerEnemy.EnemyRigidbody);
                        IEnemyData data = LoadData(StalkerEnemyDataPath);
                        IMove mover = new PhysicsMover(physic, data);
                        IRotate rotator = new SelfRotator(stalkerEnemy.EnemyTransfrom, physic);
                        IAIBehaviour aI = aIFactory.CreateAIBehavior(stalkerEnemy.AIViewComponent);
                        return new AIEnemyCore(stalkerEnemy.EnemyTransfrom, data, mover, rotator, aI);
                    }
            }
        }

        private IEnemyData LoadData(string path) => ResourceLoader.LoadObject<EnemyDataConfig>(path);
    }
}
