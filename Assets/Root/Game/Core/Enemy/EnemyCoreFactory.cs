using Root.PixelGame.Game.Enemy;
using Root.PixelGame.Tool;

namespace Root.PixelGame.Game.Core
{ 
    internal class EnemyCoreFactory
    {
        private readonly string StalkerEnemyDataPath = @"Configs/Enemy/StalkerEnemyData";

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
                        return new EnemyCore(stalkerEnemy.EnemyTransfrom, data, mover, rotator);
                    }
            }
        }

        private IEnemyData LoadData(string path) => ResourceLoader.LoadObject<EnemyDataConfig>(path);
    }
}
