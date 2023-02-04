using PixelGame.View;

namespace PixelGame.Interfaces
{
    public interface IQuestModel
    {
        bool TryComplete(LevelObjectView activator);
    }
}
