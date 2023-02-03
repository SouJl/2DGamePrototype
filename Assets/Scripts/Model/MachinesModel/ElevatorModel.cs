using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public class ElevatorModel : IElevator
    {
        private enum ElevatorState 
        {
            none,
            onEnd,
            onWork
        }

        private Rigidbody2D _transform;
        private float _speed;
        private Vector2 _upperPos;
        private Vector2 _lowerPos;
        private float _waitTime;
 
        public Vector2 Direction { get; private set; } = Vector2.up;
        public bool IsWork { get; private set; }

        private ElevatorState _state;

        private float _timerCounter;
        private Vector2 _stopPos;

        public ElevatorModel(Rigidbody2D transform, float speed, Vector2 upperPos, Vector2 lowerPos, float waitTime) 
        {
            _transform = transform;
            _speed = speed;
            _upperPos = upperPos;
            _lowerPos = lowerPos;
            _waitTime = waitTime;
        }

        public void UpdatePosition(float time)
        {
            switch (_state) 
            {
                default:
                    break;
                case ElevatorState.onWork: 
                    {
                        if (_transform.position.y <= _lowerPos.y)
                        {
                            Direction = Vector2.up;
                            _stopPos = _lowerPos;
                            if (IsWork)
                            {
                                Stop();
                                return;
                            }
                        }
                        else if (_transform.position.y >= _upperPos.y)
                        {
                            Direction = Vector2.down;
                            _stopPos = _upperPos;
                            
                            if (IsWork) 
                            {
                                Stop();
                                return;
                            }                             
                        }

                        IsWork = true;
                        _transform.velocity = Direction * _speed;

                        return;
                    }
                case ElevatorState.onEnd: 
                    {
                        if (_timerCounter < _waitTime)
                        {
                            _timerCounter += time;
                        }
                        else
                        {
                            _timerCounter = 0;
                            Start();
                        }

                        _transform.velocity = Vector2.zero;
                        
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
            _transform.position = _stopPos;
            _state = ElevatorState.onEnd;
        }
    }
}
