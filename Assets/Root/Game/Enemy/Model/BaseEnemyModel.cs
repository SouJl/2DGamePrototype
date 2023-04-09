namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyModel
    {
        
    }

    internal abstract class BaseEnemyModel : IEnemyModel
    {
        private readonly float _defaultHealth;
        private readonly float _defaultSpeed;

        public float Health { get; set; }
        public float Speed { get; set; }

        internal BaseEnemyModel(IEnemyData data)
        {
            _defaultHealth = data.MaxHealth;
            _defaultSpeed = data.Speed;

            SetDefaultValues();
        }


        public void SetDefaultValues()
        {
            Health = _defaultHealth;
            Speed = _defaultSpeed;
        }
    }
}
