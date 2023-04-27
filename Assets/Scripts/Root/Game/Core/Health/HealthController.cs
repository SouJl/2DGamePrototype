using Root.PixelGame.Game.UI;
using System;

namespace Root.PixelGame.Game.Core.Health
{
    internal interface IHealthController
    {
        IHealth HealthModel { get; }
    }
    internal class HealthController : IHealthController
    {
        private readonly IGameElementUI<IHealth> _uiElement;
        private readonly IHealth _healthModel;

        public HealthController(
            IGameElementUI<IHealth> uiElement, 
            float maxHealth)
        {
            _uiElement
                = uiElement ?? throw new ArgumentNullException(nameof(uiElement));
            _healthModel = new HealthModel(maxHealth);

            _uiElement.InitUI(_healthModel);
        }

        public IHealth HealthModel => _healthModel;
    }
}
