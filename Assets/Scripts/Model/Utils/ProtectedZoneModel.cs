using PixelGame.View;
using PixelGame.Interfaces;
using System;

namespace PixelGame.Model.Utils
{
    public sealed class ProtectedZoneModel:IDisposable
    {
        private LevelObjectTrigger _zoneTrigger;
        private IProtector _protector;

        public ProtectedZoneModel(LevelObjectTrigger trigger, IProtector protector) 
        {
            _zoneTrigger = trigger != null ? trigger : throw new ArgumentNullException(nameof(trigger));
            _protector = protector != null ? protector : throw new ArgumentNullException(nameof(protector));

            _zoneTrigger.TriggerEnter += OnContact;
            _zoneTrigger.TriggerExit += OnExit;
        }

        private void OnContact(LevelObjectView levelObject) 
        {
            _protector.StartProtection(levelObject);
        }

        private void OnExit(LevelObjectView levelObject) 
        {
            _protector.FinishProtection(levelObject);
        }

        public void Dispose()
        {
            _zoneTrigger.TriggerEnter -= OnContact;
            _zoneTrigger.TriggerExit -= OnExit;
        }
    }
}
