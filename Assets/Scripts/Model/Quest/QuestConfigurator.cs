using PixelGame.Interfaces;
using PixelGame.Configs;
using System.Collections.Generic;
using System;
using PixelGame.View;
using System.Linq;
using UnityEngine;

namespace PixelGame.Model.Quest
{
    public class QuestConfigurator
    {
        private Dictionary<QuestType, Func<IQuestModel>> _questDict;
        private readonly Dictionary<QuestSequenceType, Func<List<IQuest>, IQuestSequence>> _questSequenceDict;

        private List<QuestObjectView> _questObjects;

        public QuestConfigurator(List<QuestObjectView> questObjects)
        {
            _questObjects = questObjects;

            _questDict = new Dictionary<QuestType, Func<IQuestModel>>
            {
                { QuestType.PickUp, () => new PickUpQuestModel() },
            };

            _questSequenceDict = new Dictionary<QuestSequenceType, Func<List<IQuest>, IQuestSequence>>
            {
                { QuestSequenceType.Common, questCollection => new QuestSequenceModel(questCollection) },
            };
        }

        public IQuestSequence CreateQuestSequence(QuestSequenceConfig config)
        {
            var quests = new List<IQuest>();
            
            foreach (var qConfig in config.Quests)
            {
                var quest = CreateQuest(qConfig);
                if (quest == null) continue;
                quests.Add(quest);
            }

            // return _questSequenceDict[config.Type].Invoke(quests);
            return new QuestSequenceModel(quests);
        }

        public IQuest CreateQuest(QuestConfig config)
        {
            var questId = config.Id;
            var questView = _questObjects.FirstOrDefault(value => value.Id == config.Id);
            if (questView == null)
            {
                Debug.LogWarning($"QuestsConfigurator :: Start : Can't find view of quest {questId}");
                return null;
            }
            if (_questDict.TryGetValue(config.QuestType, out var factory))
            {
                var questModel = factory.Invoke();
                return new QuestModel(questView, questModel);
            }
            Debug.LogWarning($"QuestsConfigurator :: Start : Can't create model for quest {questId}");
            return null;
        }
    }
}
