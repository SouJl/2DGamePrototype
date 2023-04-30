using PixelGame.Tool;
using System;
using UnityEngine;

namespace PixelGame.Game.Machines
{
    internal class ElevatorController : BaseController
    {
        private readonly string _dataPath = @"Configs/Machine/ElevatorConfig";
        private readonly IElevatorView _view;
        private readonly IElevatorData _data;
        private readonly IElevator _model;


        public ElevatorController(IElevatorView view)
        {
            _view
                = view ?? throw new ArgumentNullException(nameof(view));

            _data = LoadData(_dataPath);

            _model = new ElevatorModel(_view, _data);

            _model.Start();
        }

        public override void Execute()
        {
            return;
        }

        public override void FixedExecute()
        {
            _model.UpdatePosition(Time.fixedDeltaTime);
        }

        private IElevatorData LoadData(string path)
            => ResourceLoader.LoadObject<ElevatorConfig>(path);

    }
}
