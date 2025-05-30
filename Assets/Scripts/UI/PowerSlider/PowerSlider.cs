using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PowerSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float speed = 1f;
    Coroutine sliderHandler;
    private float _currentPower;

    private List<IPowerScaler> _powerScalerObsv = new();

    private bool _isRunning = false;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Start()
    {
        StartSlider();
        GameManager.d_Instance.OnTurnEnd += ResetSliderValue;
    }
    public void StartSlider()
    {
        if (_isRunning) return;
        _isRunning = true;        
        sliderHandler = StartCoroutine(RunSlider());
        UIMN.d_Instance.OnPlayerSliderUpdate(slider.minValue);
        UIMN.d_Instance.OnEnemySliderUpdate(slider.minValue);
    }

    private IEnumerator RunSlider()
    {
        while (_isRunning)
        {
            float raw = Mathf.PingPong(Time.time * speed, 1f);
            float ease = Mathf.SmoothStep(0f, 1f, raw);
            float mapped = 1f - 2f * Mathf.Abs(ease - 0.5f);

            _currentPower = Mathf.Lerp(slider.minValue, slider.maxValue, mapped);

            slider.value = ease * slider.maxValue;

            yield return null;
        }
    }

    public void SliderNotify()
    {
        if (!_isRunning) return;
        _isRunning = false;
        if (sliderHandler != null) StopCoroutine(sliderHandler);
        float powerValue = _currentPower;
        foreach (var scaler in _powerScalerObsv)
            scaler.OnReceivedPower(powerValue);
    }
    public void ResetSliderValue()
    {
        slider.value = slider.minValue;
        StartSlider();
    }
    public void RegisterPowerScaler(IPowerScaler observer)
    {
        if (!_powerScalerObsv.Contains(observer))
            _powerScalerObsv.Add(observer);
    }
    public void UnregisterPowerScaler(IPowerScaler observer)
    {
        _powerScalerObsv.Remove(observer);
    }
    
}



