using PixelGame.Game.Core.Health;
using UnityEngine;
using UnityEngine.UI;

namespace PixelGame.Game.UI
{
    internal class PlayerHealthUI : MonoBehaviour, IGameElementUI<IHealth>
    {
        [SerializeField] private Slider _slider;

        private IHealth _healthModel;

        public void InitUI(IHealth healthModel)
        {
            _healthModel = healthModel;
            _healthModel.OnHpChanged += HealthChanged;

            _slider.maxValue = _healthModel.MaxValue;
            _slider.value = _healthModel.CurrentHealth;

            HealthChanged();
        }

        public void DeinitUI()
        {
            _healthModel.OnHpChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            _slider.value = _healthModel.CurrentHealth;
        }
    }
}
