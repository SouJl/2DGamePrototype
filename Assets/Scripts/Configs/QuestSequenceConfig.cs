using UnityEngine;

namespace PixelGame.Configs
{
    public enum QuestSequenceType 
    {
        Common,
        Resetable
    }

    [CreateAssetMenu(fileName = "QuestSequenceCfg", menuName = "Configs/Quest/QuestSequence")]
    public class QuestSequenceConfig:ScriptableObject
    {
        [SerializeField] private QuestConfig[] _quests;
        [SerializeField] private QuestSequenceType _type;
        [SerializeField] private string _reward;

        public QuestConfig[] Quests => _quests;
        public QuestSequenceType Type => _type;
        public string Reward => _reward;
    }
}
