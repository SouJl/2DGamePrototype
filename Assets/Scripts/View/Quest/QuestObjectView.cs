using UnityEngine;

namespace PixelGame.View
{
    public class QuestObjectView : LevelObjectView
    {
        [SerializeField] private int _id;

        public int Id => _id;

        public override void Awake()
        {
            base.Awake();
        }

        public virtual void ProcessComplete() { }

        public virtual void ProcessActivate() { }
    }
}
