using PixelGame.Interfaces;
using PixelGame.Model.Quest;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class QuestSequenceController : IExecute
    {
        private QuestConfigurator _questConfigurator;

        private IQuestSequence _questSequence;

        public QuestSequenceController(QuestContainerView view) 
        {
            _questConfigurator = new QuestConfigurator(view.Quests);

            _questSequence = _questConfigurator.CreateQuestSequence(view.SequenceConfig);
            _questSequence.OnSequenceCompele += SequenceComplete;
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
            Debug.Log("Sequence Complete");
        }
    }
}
