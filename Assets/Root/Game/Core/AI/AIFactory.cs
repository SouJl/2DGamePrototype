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
        private readonly string PatrolAIConfigPath= @"Enemy/AI/PatrolAIConfig";
        private readonly string StalkerAIConfigPath = @"Enemy/AI/StalkerAIConfig";

        public IAIBehaviour CreateAIBehavior(IAIViewComponent aIView)
        {
            switch (aIView)
            {
                default:
                    return null;
                case PatrolViewComponent patrolAIView:
                    {
                        var config = LoadConfig(PatrolAIConfigPath);
                        var model = new PatrolAIModel(config, patrolAIView.PatrolWayPoints);
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
            }
        }

        private IAIConfig LoadConfig(string path) 
            => ResourceLoader.LoadObject<AIConfig>(path);
    }
}
