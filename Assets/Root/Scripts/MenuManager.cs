using PixelGame.Tool;
using UnityEngine;
using UnityEngine.UI;

namespace PixelGame 
{
    internal class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button _startGammeButton;
        [SerializeField] private Button _settingMenuButton;
        [SerializeField] private Button _exitGameButton;

        private int GameSceneIndex = 1;

        void Start()
        {
            _startGammeButton.onClick.AddListener(StartGame);
            _settingMenuButton.onClick.AddListener(OpenSettingMenu);
            _exitGameButton.onClick.AddListener(ExitGame);
        }

        private void OnDestroy()
        {
            _startGammeButton.onClick.RemoveListener(StartGame);
            _settingMenuButton.onClick.RemoveListener(OpenSettingMenu);
            _exitGameButton.onClick.RemoveListener(ExitGame);
        }

        private void StartGame()
        {
            GameSceneLoader.Instance.LoadScene(GameSceneIndex);
        }

        private void OpenSettingMenu()
        {
            Debug.Log("Settings Menu");
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}

