using PixelGame.Interfaces;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model.Quest
{
    public class InteractQuestModel : IQuestModel
    {
        private const string TargetTag = "Player";

        public bool TryComplete(LevelObjectView activator)
        {
            if (activator.gameObject.CompareTag(TargetTag)) 
            {
                return Input.GetKey(KeyCode.E);
            }
            return false;
        }
    }
}
