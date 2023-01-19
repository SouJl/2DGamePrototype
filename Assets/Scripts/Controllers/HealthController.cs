using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class HealthController : IExecute
    {
        private IHealth _healthModel;
        private HealhBarView _healhView;

        private float _hpDecreaseDelay = 2f;
        private float _lastTime;

        public HealthController(float healthPoints, HealhBarView healhView) 
        {
            _healthModel = new HealthModel(healthPoints);
            _healhView = healhView;
            _healhView.Initialize(_healthModel);
            _healthModel.CurrentHealth = _healthModel.MaxHealth;
            _lastTime = Time.time;
        }

        public void Execute()
        {
            if (_healthModel.CurrentHealth == 0) return;

            if(Time.time - _lastTime > _hpDecreaseDelay) 
            {
                _healthModel.CurrentHealth -= 10f;
                _lastTime = Time.time;
            }
        }

        public void FixedExecute()
        {
            
        }
    }
}
