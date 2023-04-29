using PixelGame.Components.AI;
using PixelGame.Game.AI.Model;
using PixelGame.Tool;
using System;

namespace PixelGame.Game.AI
{
    internal interface IAIFactory
    {
        IAIBehaviour CreateAIBehavior(IAIComponent aIView);
    }

    internal class AIFactory : IAIFactory
    {
        private readonly ITargetSelector _targetSelector;

        public AIFactory(ITargetSelector targetSelector) 
        {
            _targetSelector 
                = targetSelector ?? throw new ArgumentNullException(nameof(targetSelector));
        }

        public IAIBehaviour CreateAIBehavior(IAIComponent aIView)
        {
            switch (aIView)
            {
                default:
                    return null;
                case ChaserAIComponent chaserAI:
                    {
                        var model = new StalkerAIModel(chaserAI.AIData);
                        var seeker = new SeekerController(
                            chaserAI.Seeker,
                            chaserAI.Handler,
                            _targetSelector, 
                            model);
                        var aiBehavior = new SeekerAI(chaserAI.AIData, seeker, model);
                        return aiBehavior;
                    }
                case PatrolAIComponent patrolAI: 
                    {
                        var model = new PatrolAIModel(patrolAI.AIData, patrolAI.PatrolWayPoints, _targetSelector);
                        var seeker = new PatrolPathController(
                            patrolAI.Seeker,
                            patrolAI.Handler,
                            model);
                        var aiBehavior = new PatrolAI(patrolAI.AIData, seeker, model);
                        return aiBehavior;
                    }
            }
        }
    }
}
