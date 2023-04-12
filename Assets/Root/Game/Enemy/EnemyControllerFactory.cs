using Root.PixelGame.Animation;
using Root.PixelGame.Game.Core;
using Root.PixelGame.StateMachines;
using Root.PixelGame.Tool;
using System;
using System.Collections.Generic;

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
                        IAnimatorController animator = GetAnimatorController(stalkerEnemy);
                        IEnemyCore core = GetEnemyCore(stalkerEnemy, data);
                        IStateMachine stateMachine = new StateMachine(); 
                        
                        return new EnemyController(stalkerEnemy, model, core, animator, stateMachine);
                    }
                case PatrolEnemyView patrolEnemy: 
                    {
                        IEnemyData data = LoadData(PatrolEnemyDataPath);
                        IEnemyModel model = new PatrolEnemyModel(data);
                        IAnimatorController animator = GetAnimatorController(patrolEnemy);
                        IEnemyCore core = GetEnemyCore(patrolEnemy, data);
                        IStateMachine stateMachine = new StateMachine();

                        return new EnemyController(patrolEnemy, model, core, animator, stateMachine);
                    }
            }
        }

        private IEnemyData LoadData(string path) => ResourceLoader.LoadObject<EnemyDataConfig>(path);

        private IAnimatorController GetAnimatorController(EnemyView view)  
            =>  new SpriteAnimatorController(view.Animation.SpriteRenderer, view.Animation.AnimationConfig);

        private IEnemyCore GetEnemyCore(IEnemyView view, IEnemyData data)
        {
            var coreFactory = new EnemyCoreFactory(data);
            return coreFactory.GetEnemyCore(view);
        }
    }
}
