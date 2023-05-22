using PixelGame.Tool.Audio;

namespace PixelGame.Tool
{
    internal class GameSystem
    {
        private ExecutableList _gameExecutables = new ExecutableList();

        private GameEndSystem _gameEndSystem;

        private bool _isWorking;

        public void Start(
            PlayerGameSystem playerSystem, 
            EnemiesGameSystem enemiesSystem, 
            LevelObjectsGameSystem levelObjectsSystem,
            GameEndSystem gameEndSystem)
        {
            _gameExecutables.Add(playerSystem.GetExecutable());
            _gameExecutables.Add(enemiesSystem.GetExecutable());
            _gameExecutables.Add(levelObjectsSystem.GetExecutable());
 
            levelObjectsSystem.OnRestart += gameEndSystem.RestartGame;
            levelObjectsSystem.OnGameEnd += gameEndSystem.GameEnd;
            _gameEndSystem = gameEndSystem;
            _gameEndSystem.OnEndCallBack += End;

            AudioManager.Instance.PlayMusic("MainTheme");
            AudioManager.Instance.PlayeAmbient("WaterDrips");

            _isWorking = true;
        }

        public void WorkUpdate()
        {
            if (!_isWorking) 
                return;

            while (_gameExecutables.MoveNext())
            {
                IExecute tmp = (IExecute)_gameExecutables.Current;
                tmp.Execute();
            }
            _gameExecutables.Reset();
        }

        public void WorkFixedUpdate()
        {
            if (!_isWorking) 
                return;

            while (_gameExecutables.MoveNext())
            {
                IExecute tmp = (IExecute)_gameExecutables.Current;
                tmp.FixedExecute();
            }
            _gameExecutables.Reset();
        }

        public void End()
        {
            _isWorking = false;

            _gameExecutables.Clear();
            
            AudioManager.Instance.Music.Stop();
            AudioManager.Instance.Ambient.Stop();
        }  
    }
}
