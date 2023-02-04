using PixelGame.Interfaces;
using PixelGame.View;

namespace PixelGame.Model.Quest
{
    public class PickUpQuestModel : IQuestModel
    {
        private const string TargetTag = "Player";

        public bool TryComplete(LevelObjectView activator)
        {
            return activator.gameObject.CompareTag(TargetTag);
        }
    }
}
