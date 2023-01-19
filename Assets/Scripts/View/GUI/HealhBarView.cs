using UnityEngine;
using TMPro;
using PixelGame.Interfaces;

namespace PixelGame.View
{
    public class HealhBarView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healtPointText;

        private string _header = "Health";

        private IHealth _healthModel;

        public void Initialize(IHealth healthModel) 
        {
            _healthModel = healthModel;
            _healthModel.OnHpChanged += HpChanged;
            HpChanged(_healthModel.MaxHealth);
        }

        private void HpChanged(float hpValue) 
        {
            _healtPointText.text = $"{_header}: {hpValue}";
        }

        ~HealhBarView() 
        {
            _healthModel.OnHpChanged -= HpChanged;
        }
    }
}
