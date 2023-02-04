using UnityEngine;

namespace PixelGame.Configs
{
    public enum QuestType 
    {
        Switch,
        PickUp,
    }

    [CreateAssetMenu(fileName = "QuestCfg", menuName = "Configs/Quest/QuestConfig")]
    public class QuestConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private QuestType _questType;

        public int Id => _id;
        public QuestType QuestType => _questType;               
    }
}
