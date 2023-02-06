using PixelGame.Interfaces;
using System;

namespace PixelGame.Model.Quest
{
    public abstract class AbstractQuestSequence : IQuestSequence
    {
        public abstract bool IsDone { get; }

        public Action OnSequenceCompele { get; set; }

        protected abstract void OnQuestCompleted(object sender, IQuest quest);

        public abstract void Dispose();
    }
}
