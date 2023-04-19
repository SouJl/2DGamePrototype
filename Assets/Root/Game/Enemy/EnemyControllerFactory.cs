using Root.PixelGame.Animation;
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
                        IEnemyModel model = new StalkerEnemyModel(stalkerEnemy.transform, data);
                        IAnimatorController animator = GetAnimatorController(stalkerEnemy);
                        
                        ITargetSelector targetSelector = new ManualTargetSelector(stalkerEnemy.StalkerTarget);

                        var coreFactory = new EnemyCoreFactory(data, targetSelector);
                        IEnemyCore core = GetEnemyCore(coreFactory, stalkerEnemy.CoreComponent);
                        
                        IStateHandler stateHandler = new EnemyStatesHandler(core, animator);                  
                        
                        return new EnemyController(stalkerEnemy, model, animator, stateHandler);
                    }
                case ChaserEnemyView chaserEnemy: 
                    {
                        IEnemyData data = LoadData(ChaserEnemyDataPath);
                        IEnemyModel model = new ChaserEnemyModel(chaserEnemy.transform, data);
                        IAnimatorController animator = GetAnimatorController(chaserEnemy);
                        
                        ITargetSelector targetSelector = new DynamicTargetSelector();

                        var coreFactory = new EnemyCoreFactory(data, targetSelector);
                        IEnemyCore chaseCore = GetEnemyCore(coreFactory, chaserEnemy.ChaseAICore);
                        IEnemyCore patrolCore = GetEnemyCore(coreFactory, chaserEnemy.PatrolAICore);

                        IStateHandler stateHandler 
                            = new ChaserEnemyStatesHandler(chaseCore, patrolCore, animator);
                        
                        return new ChaserEnemyController(chaserEnemy, model, animator, stateHandler, targetSelector, chaserEnemy.TargetLocator, chaserEnemy.ChaseBreakDistance);
                    }
                case PathSeekerEnemyView pathSeeker:
                    {
                        IEnemyData data = LoadData(PatrolEnemyDataPath);
                        IEnemyModel model = new PatrolEnemyModel(pathSeeker.transform, data);
                        IAnimatorController animator = GetAnimatorController(pathSeeker);
                        ITargetSelector targetSelector = new DynamicTargetSelector();

                        var coreFactory = new EnemyCoreFactory(data, targetSelector);
                        
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
