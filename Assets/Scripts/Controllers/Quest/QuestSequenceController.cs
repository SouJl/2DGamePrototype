using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.Model.Quest;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class QuestSequenceController : IExecute
    {
        private readonly QuestConfigurator _questConfigurator;
        private readonly IQuestSequence _questSequence;
        private readonly string _result;

        public QuestSequenceController(QuestContainerView view, PlayerModel player) 
        {
            _questConfigurator = new QuestConfigurator(view.Quests, player);

            _questSequence = _questConfigurator.CreateQuestSequence(view.SequenceConfig);
            _questSequence.OnSequenceCompele += SequenceComplete;

            _result = view.SequenceConfig.Reward;
        }

        public void Execute()
        {
            return;
        }

        public void FixedExecute()
        {
            return;
        }

        private void SequenceComplete() 
        {
            Debug.Log(_result);

        }
    }
}
