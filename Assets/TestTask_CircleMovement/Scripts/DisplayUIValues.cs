using TMPro;
using Zenject;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TestTask_CircleMovement.Scripts
{
    public class DisplayUIValues : MonoBehaviour
    {
        [SerializeField] private Slider _moveSpeedSlider;
        [SerializeField] private TextMeshProUGUI _moveSpeedValueText;

        private CircleSettings _circleSettings;

        [Inject]
        private void Construct(CircleSettings circleSettings)
        {
            _circleSettings = circleSettings;
        }

        private void Awake()
        {
            UpdateTextValue(_circleSettings.DefaultMoveSpeed);
            UpdateSliderValue(_circleSettings.DefaultMoveSpeed);
        }

        private void OnEnable()
        {
            _moveSpeedSlider.onValueChanged.AddListener(UpdateTextValue);
        }

        private void OnDestroy()
        {
            _moveSpeedSlider.onValueChanged.RemoveListener(UpdateTextValue);
        }

        private void UpdateTextValue(float value)
        {
            _moveSpeedValueText.text = value.ToString();
        }

        private void UpdateSliderValue(float value)
        {
            _moveSpeedSlider.value = value;
        }
    }
}