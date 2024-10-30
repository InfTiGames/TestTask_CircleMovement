using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider _moveSpeedSlider;
    public event Action<float> OnSpeedChanged;

    private void Awake()
    {
        _moveSpeedSlider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _moveSpeedSlider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        OnSpeedChanged?.Invoke(value);
    }

    private void OnDisable()
    {
        _moveSpeedSlider.onValueChanged?.RemoveListener(HandleSliderValueChanged);
    }
}