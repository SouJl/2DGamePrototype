using PixelGame.Interfaces;
using PixelGame.View;

namespace PixelGame.Controllers
{
    public class MachinesController : IExecute
    {
        private LevelMachinesContainerView _levelMachines;
        private ListExecuteController _executeController;

        public MachinesController(LevelMachinesContainerView levelMachines) 
        {
            _levelMachines = levelMachines;
            _executeController = new ListExecuteController();

            for(int i =0; i < _levelMachines.Elevators.Length; i++) 
            {
                _executeController.AddExecuteObject(new ElevatorController(_levelMachines.Elevators[i]));
            }
        }

        public void Execute()
        {
            if (_executeController == null) return;

            while (_executeController.MoveNext())
            {
                IExecute tmp = (IExecute)_executeController.Current;
                tmp.Execute();
            }
            _executeController.Reset();
        }

        public void FixedExecute()
        {
            if (_executeController == null) return;

            while (_executeController.MoveNext())
            {
                IExecute tmp = (IExecute)_executeController.Current;
                tmp.FixedExecute();
            }
            _executeController.Reset();
        }
    }
}
