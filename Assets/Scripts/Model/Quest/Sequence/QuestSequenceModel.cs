using PixelGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PixelGame.Model.Quest
{
    public class QuestSequenceModel : AbstractQuestSequence
    {
        private List<IQuest> _quests;

        public override bool IsDone => _quests.All(q => q.IsCompleted);

        public QuestSequenceModel(List<IQuest> quests)
        {
            _quests = quests ?? throw new ArgumentNullException(nameof(_quests));
            Subscribe();
            Reset(0);
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

        private void Reset(int index) 
        {
            if (index < 0 || index >= _quests.Count) return;
            var nextQuest = _quests[index];
            if (nextQuest.IsCompleted) OnQuestCompleted(this, nextQuest);
            else _quests[index].Reset();

        }

        protected override void OnQuestCompleted(object sender, IQuest quest)
        {
            var index = _quests.IndexOf(quest);            
            if (IsDone) 
            {
                OnSequenceCompele?.Invoke();
                return;
            }
            Reset(++index);
        }

        public override void Dispose()
        {
            Unsubscribe();
            foreach (var quest in _quests) quest.Dispose();
        }
    }
}
