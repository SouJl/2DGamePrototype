using System;
using UnityEngine;

namespace PixelGame.Game.Machines
{
    internal interface IElevator
    {
        bool IsWork { get; }

        Vector2 Direction { get; }

        void Start();

        void Stop();

        void UpdatePosition(float time);
    }

    internal class ElevatorModel : IElevator
    {
        private enum ElevatorState
        {
            none,
            onEnd,
            onWork
        }

        private readonly IElevatorView _view;
        private readonly IElevatorData _data;


        private ElevatorState _state;
        private float _timerCounter;
        private Vector2 _stopPos;

        public Vector2 Direction { get; private set; } = Vector2.up;
        public bool IsWork { get; private set; }

        public ElevatorModel(
            IElevatorView view, 
            IElevatorData data)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            _data
                = data ?? throw new ArgumentNullException(nameof(data));
        }

        public void UpdatePosition(float time)
        {
            switch (_state)
            {
                default:
                    break;
                case ElevatorState.onWork:
                    {
                        if (_view.MachineTransfrom.position.y <= _view.LowerPos.y)
                        {
                            Direction = Vector2.up;
                            _stopPos = _view.LowerPos;
                            if (IsWork)
                            {
                                Stop();
                                return;
                            }
                        }
                        else if (_view.MachineTransfrom.position.y >= _view.UpperPos.y)
                        {
                            Direction = Vector2.down;
                            _stopPos = _view.UpperPos;

                            if (IsWork)
                            {
                                Stop();
                                return;
                            }
                        }

                        IsWork = true;
                        _view.Rigidbody.velocity = Direction * _data.Speed;

                        return;
                    }
                case ElevatorState.onEnd:
                    {
                        if (_timerCounter < _data.WaitTime)
                        {
                            _timerCounter += time;
                        }
                        else
                        {
                            _timerCounter = 0;
                            Start();
                        }

                        _view.Rigidbody.velocity = Vector2.zero;

                        return;
                    }
            }
        }

        public void Start()
        {
            _state = ElevatorState.onWork;
        }

        public void Stop()
        {
            IsWork = false;
            _view.MachineTransfrom.position = _stopPos;
            _state = ElevatorState.onEnd;
        }
    }
}
