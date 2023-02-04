using UnityEngine;

namespace PixelGame.Configs
{
    public enum QuestSequenceType 
    {
        Common,
        Resettable
    }

    [CreateAssetMenu(fileName = "QuestSequenceCfg", menuName = "Configs/Quest/QuestSequence")]
    public class QuestSequenceConfig:ScriptableObject
    {
        [SerializeField] private QuestConfig[] _quests;
        [SerializeField] private QuestSequenceType _type;

        public QuestConfig[] Quests => _quests;
        public QuestSequenceType Type => Type;
    }
}
