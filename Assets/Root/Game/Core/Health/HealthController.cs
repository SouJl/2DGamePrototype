using Root.Game.UI;
using System;

namespace Root.PixelGame.Game.Core.Health
{
    internal interface IHealthController
    {
        IHealth HealthModel { get; }
    }
    internal class HealthController : IHealthController
    {
        private readonly IHealthUI _healthUI;
        private readonly IHealth _healthModel;

        public HealthController(
            IHealthUI healthUI, 
            float maxHealth)
        {
            _healthUI 
                = healthUI ?? throw new ArgumentNullException(nameof(healthUI));
            _healthModel = new HealthModel(maxHealth);

            _healthUI.InitUI(_healthModel);
        }

        public IHealth HealthModel => _healthModel;

        

    }
}
