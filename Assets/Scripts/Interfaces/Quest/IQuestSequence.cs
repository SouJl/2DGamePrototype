using System;

namespace PixelGame.Interfaces
{
    public interface IQuestSequence: IDisposable
    {
        bool IsDone { get; }

        Action OnSequenceCompele { get; set; }
    }
}
