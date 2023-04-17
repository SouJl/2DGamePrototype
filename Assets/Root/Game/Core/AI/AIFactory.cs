using Root.PixelGame.Components.AI;
using Root.PixelGame.Game.AI.Model;
using Root.PixelGame.Tool;
using System;

namespace Root.PixelGame.Game.AI
{
    internal interface IAIFactory
    {
        IAIBehaviour CreateAIBehavior(IAIViewComponent aIView);
    }

    internal class AIFactory : IAIFactory
    {
        private readonly string PatrolAIConfigPath= @"Enemy/AI/PatrolConfig";
        private readonly string StalkerAIConfigPath = @"Enemy/AI/StalkerAIConfig";

        public IAIBehaviour CreateAIBehavior(IAIViewComponent aIView)
        {
            switch (aIView)
            {
                default:
                    return null;
                case PatrolViewComponent patrolView:
                    {
                        var config = LoadConfig(PatrolAIConfigPath);
                        var model = new PatrolModel(config, patrolView.PatrolWayPoints);
                        var aiBehavior = new SimpleAI(config, model);
                        return aiBehavior;
                    }
                case SeekerAIViewComponent seekerAIView:
                    {
                        var config = LoadConfig(StalkerAIConfigPath);
                        var model = new StalkerAIModel(config);
                        var seeker = new SeekerController(
                            seekerAIView.Seeker, 
                            seekerAIView.Handler, 
                            seekerAIView.Target, 
                            model);
                        var aiBehavior = new SeekerAI(config, seeker, model);
                        return aiBehavior;
                    }
                case PatrolAIComponent patrolAI: 
                    {
                        var config = LoadConfig(PatrolAIConfigPath);
                        var model = new PatrolAIModel(config, patrolAI.PatrolWayPoints);
                        var seeker = new PatrolPathController(
                            patrolAI.Seeker,
                            patrolAI.Handler,
                            model);
                        var aiBehavior = new PatrolAI(config, seeker, model);
                        return aiBehavior;
                    }
            }
        }

        private IAIConfig LoadConfig(string path) 
            => ResourceLoader.LoadObject<AIConfig>(path);
    }
}
