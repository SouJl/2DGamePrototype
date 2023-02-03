using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class ElevatorController : IExecute
    {
        private IElevator _elevator;

        private ElevatorView _view;

        public ElevatorController(ElevatorView view) 
        {
            _view = view;
            _elevator = new ElevatorModel(_view.Rigidbody, _view.Speed, _view.UpperPos, _view.LowerPos, _view.WaitTime);
            _elevator.Start();
        }

        public void Execute()
        {
            return;
        }

        public void FixedExecute()
        {
            _elevator.UpdatePosition(Time.fixedDeltaTime);
        }
    }
}
