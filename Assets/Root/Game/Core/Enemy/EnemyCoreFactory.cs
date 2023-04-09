using Root.PixelGame.Game.AI;
using Root.PixelGame.Game.Enemy;
using System;

namespace Root.PixelGame.Game.Core
{ 
    internal class EnemyCoreFactory
    {
        private readonly IEnemyData _data;
        private readonly IAIFactory aIFactory;

        public EnemyCoreFactory(IEnemyData data) 
        {
            _data 
                = data ?? throw new ArgumentNullException(nameof(data));

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
                        IMove mover = new PhysicsMover(physic, _data);
                        IRotate rotator = new SelfRotator(stalkerEnemy.EnemyTransfrom, physic);
                        IAIBehaviour aI = aIFactory.CreateAIBehavior(stalkerEnemy.AIViewComponent);
                        return new AIEnemyCore(stalkerEnemy.EnemyTransfrom, _data, mover, rotator, aI);
                    }
                case PatrolEnemyView patrolEnemy: 
                    {
                        IPhysicModel physic = new PhysicModel(patrolEnemy.EnemyRigidbody);
                        IMove mover = new PhysicsMover(physic, _data);
                        IRotate rotator = new SelfRotator(patrolEnemy.EnemyTransfrom, physic);
                        IAIBehaviour aI = aIFactory.CreateAIBehavior(patrolEnemy.AIViewComponent);
                        return new AIEnemyCore(patrolEnemy.EnemyTransfrom, _data, mover, rotator, aI);
                    }
            }
        }
    }
}
