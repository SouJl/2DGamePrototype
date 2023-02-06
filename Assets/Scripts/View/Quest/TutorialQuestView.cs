using PixelGame.Model.Quest;
using System;
using UnityEngine;

namespace PixelGame.View
{
    [RequireComponent(typeof(Collider2D))]
    public class TutorialQuestView:QuestObjectView
    {
        [SerializeField] private InputAction _monitoringAction;
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private string _tutorialStartText;
        [SerializeField] private string _tutorialEndText;

        public InputAction MonitoringAction => _monitoringAction;

        public override void Awake()
        {
            base.Awake();
        }


        private void OnValidate()
        {
            _collider2D ??= GetComponent<Collider2D>();
        }


        public override void ProcessActivate()
        {
            base.ProcessActivate();
            Debug.Log(_tutorialStartText);
            
        }

        public override void ProcessComplete()
        {
            base.ProcessComplete();
            Debug.Log(_tutorialEndText);
            gameObject.SetActive(false);
        }

        protected override void CollisionStay(Collider2D collision)
        {
            base.CollisionStay(collision);
            if (collision.TryGetComponent(out LevelObjectView collideObject))
            {
                OnLevelObjectContact?.Invoke(collideObject);
            }
        }
    }
}
