using UnityEngine;

namespace PixelGame.Model
{
    public class LiftModel
    {
        private SliderJoint2D _joint;
        private float _speed;

        private JointMotor2D _motor;

        public LiftModel(SliderJoint2D joint, float speed) 
        {
            _joint = joint;
            _speed = speed;
            _motor = _joint.motor;
        }

        public bool IsEnd() => true;

        public void ChangeDirection(bool state) 
        {
            _motor.motorSpeed = state? _speed : -_speed;
        }

    }
}
