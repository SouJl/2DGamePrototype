﻿using Root.PixelGame.Animation;
using Root.PixelGame.Components.Core;
using Root.PixelGame.Game.Core;
using Root.PixelGame.StateMachines;
using Root.PixelGame.Tool;

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
        private readonly string ChaserEnemyDataPath = @"Enemy/ChaserEnemyData";

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
                        var coreFactory = new EnemyCoreFactory(data);
                        IEnemyCore core = GetEnemyCore(coreFactory, stalkerEnemy.CoreComponent);
                        IStateHandler stateHandler = new EnemyStatesHandler(core, animator);                  
                        return new EnemyController(stalkerEnemy, model, animator, stateHandler);
                    }
                case ChaserEnemyView chaserEnemy: 
                    {
                        IEnemyData data = LoadData(ChaserEnemyDataPath);
                        IEnemyModel model = new PatrolEnemyModel(data);
                        IAnimatorController animator = GetAnimatorController(chaserEnemy);
                        var coreFactory = new EnemyCoreFactory(data);
                        IEnemyCore chaseCore = GetEnemyCore(coreFactory, chaserEnemy.ChaseAICore);
                        IStateHandler stateHandler = new EnemyStatesHandler(chaseCore, animator);
                        return new EnemyController(chaserEnemy, model, animator, stateHandler);
                    }
                case PathSeekerEnemyView pathSeeker:
                    {
                        IEnemyData data = LoadData(PatrolEnemyDataPath);
                        IEnemyModel model = new PatrolEnemyModel(data);
                        IAnimatorController animator = GetAnimatorController(pathSeeker);
                        var coreFactory = new EnemyCoreFactory(data);
                        IEnemyCore core = GetEnemyCore(coreFactory, pathSeeker.CoreComponent);
                        IStateHandler stateHandler = new EnemyStatesHandler(core, animator);

                        return new EnemyController(pathSeeker, model, animator, stateHandler);
                    }
            }
        }

        private IEnemyData LoadData(string path) => ResourceLoader.LoadObject<EnemyDataConfig>(path);

        private IAnimatorController GetAnimatorController(EnemyView view)  
            =>  new SpriteAnimatorController(view.Animation.SpriteRenderer, view.Animation.AnimationConfig);

        private IEnemyCore GetEnemyCore(ICoreFactory<IEnemyCore, ICoreComponent> coreFactory, ICoreComponent coreComponent) 
            => coreFactory.GetCore(coreComponent);
    }
}
