using PixelGame.Interfaces;
using PixelGame.View;
using System;

namespace PixelGame.Model.Quest
{
    public class TutorialModel : IQuest
    {
        private bool _active;
        private bool _isWait;

        private TutorialQuestView _view;
        private IQuestModel _model;


        public TutorialModel(TutorialQuestView view, IQuestModel model)
        {
            _view = view;
            _model = model;
            _isWait = true;
        }

        private void OnContact(LevelObjectView levelObject)
        {
            if (_isWait)
            {
                _view.ProcessActivate();
                _isWait = false;
            }

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
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnContact;
            _view.ProcessComplete();
        }
    }
}
