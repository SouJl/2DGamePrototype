using Root.PixelGame.Components.AI;
using Root.PixelGame.Game.AI.Model;
using Root.PixelGame.Tool;

namespace Root.PixelGame.Game.AI
{
    internal interface IAIFactory
    {
        IAIBehaviour CreateAIBehavior(IAIComponent aIView);
    }

    internal class AIFactory : IAIFactory
    {
        public IAIBehaviour CreateAIBehavior(IAIComponent aIView)
        {
            switch (aIView)
            {
                default:
                    return null;
                case ChaseAIComponent chaserAI:
                    {
                        var model = new StalkerAIModel(chaserAI.AIData);
                        var seeker = new SeekerController(
                            chaserAI.Seeker,
                            chaserAI.Handler,
                            chaserAI.Target, 
                            model);
                        var aiBehavior = new SeekerAI(chaserAI.AIData, seeker, model);
                        return aiBehavior;
                    }
                case PatrolAIComponent patrolAI: 
                    {
                        var model = new PatrolAIModel(patrolAI.AIData, patrolAI.PatrolWayPoints);
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
