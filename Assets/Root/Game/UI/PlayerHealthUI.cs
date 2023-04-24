using Root.PixelGame.Game.Core.Health;
using TMPro;
using UnityEngine;

namespace Root.Game.UI
{
    internal class PlayerHealthUI : MonoBehaviour, IHealthUI
    {
        [SerializeField] private TMP_Text _playerHelthDesctiption;

        private IHealth _healthModel;

        public void InitUI(IHealth healthModel)
        {
            _healthModel = healthModel;
            _healthModel.OnHpChanged += HealthChanged;
            HealthChanged();
        }

        public void DeinitUI()
        {
            _healthModel.OnHpChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            _playerHelthDesctiption.text = $"Health: {_healthModel.CurrentHealth}";
        }
    }
}
