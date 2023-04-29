
using UnityEngine;

namespace PixelGame.Game.Machines
{
    internal class ElevatorController : BaseController
    {
        private IElevator _elevator;

        private ElevatorView  _view;

        public ElevatorController(ElevatorView view)
        {
            _view = view;
            
            _elevator 
                = new ElevatorModel(
                    _view.Rigidbody, 
                    _view.Speed,
                    _view.UpperPos,
                    _view.LowerPos,
                    _view.WaitTime);

            _elevator.Start();
        }

        public override void Execute()
        {
            return;
        }

        public override void FixedExecute()
        {
            _elevator.UpdatePosition(Time.fixedDeltaTime);
        }
    }
}
