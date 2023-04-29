using TMPro;
using UnityEngine;

namespace PixelGame.Components
{
    internal class GameEndComponent : MonoBehaviour
    {
        [SerializeField] private TMP_Text _gameEndText;

        private void Awake()
        {
            _gameEndText.text = "Level Completed!";
            _gameEndText.gameObject.SetActive(false);
        }

        public void ShowGameEndText() 
            => _gameEndText.gameObject.SetActive(true);

    }
}
