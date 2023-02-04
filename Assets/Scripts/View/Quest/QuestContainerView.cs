using UnityEngine;
using PixelGame.Configs;
using System.Linq;
using System.Collections.Generic;

namespace PixelGame.View
{
    public class QuestContainerView : MonoBehaviour
    {
        [SerializeField] private QuestSequenceConfig _sequenceConfig;
        [SerializeField] private QuestObjectView[] _questsObjects;


        public QuestSequenceConfig SequenceConfig => _sequenceConfig;
        public List<QuestObjectView> Quests => Enumerable.ToList(_questsObjects);
    }
}
