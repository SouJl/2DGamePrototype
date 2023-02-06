using PixelGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PixelGame.Model.Quest
{
    public class ResetableSequenceModel : AbstractQuestSequence
    {
        private readonly List<IQuest> _quests;
        private int _currentIndex;


        public override bool IsDone => _quests.All(q => q.IsCompleted);

        public ResetableSequenceModel(List<IQuest> quests) 
        {
            _quests = quests ?? throw new ArgumentNullException(nameof(_quests));
            Subscribe();
            ResetQuests();
        }

        private void Subscribe()
        {
            foreach (var quest in _quests)
            {
                quest.Completed += OnQuestCompleted;
            }

        }

        private void Unsubscribe()
        {
            foreach (var quest in _quests)
            {
                quest.Completed -= OnQuestCompleted;
            }
        }

        protected override void OnQuestCompleted(object sender, IQuest quest)
        {
            var index = _quests.IndexOf(quest);
            if (_currentIndex == index)
            {
                _currentIndex++;
                if (IsDone) OnSequenceCompele?.Invoke();
            }
            else
            {
                ResetQuests();
            }
        }


        private void ResetQuests()
        {
            _currentIndex = 0;
            foreach (var quest in _quests)
            {
                quest.Reset();
            }

        }

        public override void Dispose()
        {
            Unsubscribe();
            foreach (var quest in _quests) quest.Dispose();
        }
    }
}
