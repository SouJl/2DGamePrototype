using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model
{
    public class LiftModel
    {
        private SliderJoint2D _joint;
        private float _speed;
        private float _stayTime;

        private JointMotor2D _motor;
        private LiftView _view;
        private float _currentSpeed;

        private bool _isChngeDirection;
        private float _timerCounter;

        public LiftModel(LiftView joint, float speed, float stayTime) 
        {     
            _joint = joint.Joint;
            _speed = speed;
            _stayTime = stayTime;
            _motor = _joint.motor;

            _view = joint;
            _view.MaxLimitTrigger.OnLevelObjectContact += OnTouchTrigger;
            _view.MinLimitTrigger.OnLevelObjectContact += OnTouchTrigger;

            _currentSpeed = _speed;
            _motor.motorSpeed = _currentSpeed;
            _timerCounter = 0;
        }
      
        public void Upate(float time) 
        {
            if (!_isChngeDirection) return;

            if (_timerCounter > _stayTime) 
            {
                if (_currentSpeed < 0) _motor.motorSpeed = _speed;
                if (_currentSpeed > 0) _motor.motorSpeed = -_speed;
                
                _currentSpeed = _motor.motorSpeed;
                _joint.motor = _motor;

                _timerCounter = 0;

                _isChngeDirection = false;
            }
            else
            {
                _timerCounter += time;
            }
        }

        private void OnTouchTrigger(LevelObjectView levelObject)
        {
            if (levelObject.tag != "Joint") return;

            _isChngeDirection = true;
        }
    }
}
