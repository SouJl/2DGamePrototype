using PixelGame.Interfaces;
using PixelGame.View;
using System;

namespace PixelGame.Model.Quest
{
    public class QuestModel : IQuest
    {
        private bool _active;

        private QuestObjectView _view;
        private IQuestModel _model;


        public QuestModel(QuestObjectView view, IQuestModel model) 
        {
            _view = view;
            _model = model;
        }

        private void OnContact(LevelObjectView levelObject)
        {
            var completed = _model.TryComplete(levelObject);
            if (completed) Complete();
        }

        private void Complete() 
        {
            if (!_active) return;
            _active = false;
            IsCompleted = true;
            _view.OnLevelObjectContact -= OnContact;
            _view.ProcessComplete();
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this, this);
        }

        public bool IsCompleted { get; private set; }

        public event EventHandler<IQuest> Completed;

        public void Reset()
        {
            if (_active) return;
            _active = true;
            IsCompleted = false;
            _view.OnLevelObjectContact += OnContact;
            _view.ProcessActivate();

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
