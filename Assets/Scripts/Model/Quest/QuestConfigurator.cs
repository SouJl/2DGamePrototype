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
        private readonly List<QuestObjectView> _questObjects;
        private readonly PlayerModel _player;

        public QuestConfigurator(List<QuestObjectView> questObjects, PlayerModel player)
        {
            _questObjects = questObjects;
            _player = player;
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

            switch (config.Type) 
            {
                default: return null;

                case QuestSequenceType.Common: 
                    {
                        return new QuestSequenceModel(quests);
                    }
                case QuestSequenceType.Resetable: 
                    {
                        return new ResetableSequenceModel(quests);
                    }
            }
           
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

            IQuestModel questModel = null;

            switch (config.QuestType) 
            {
                case QuestType.Interact: 
                    {
                        questModel = new InteractQuestModel();
                        return new QuestModel(questView, questModel);
                    }
                case QuestType.PickUp: 
                    {
                        questModel = new PickUpQuestModel();

                        return new QuestModel(questView, questModel);
                    }
                case QuestType.Tutorial: 
                    {
                        var view = questView as TutorialQuestView;
                        if (view) 
                        {
                            questModel = new InputQuestModel(_player, view.MonitoringAction);
                            return new TutorialModel(view, questModel);
                        }
                        break;
                    }
            }

            Debug.LogWarning($"QuestsConfigurator :: Start : Can't create model for quest {questId}");
            return null;

        }
    }
}
