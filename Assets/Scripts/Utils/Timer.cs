using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _timerLabel;
    
    [SerializeField] 
    private Slider _slider;

    private bool _isEndTime;
    private float _timer;

    public Action OnEndTime;

    private float _maxTime;
    
    public void Init(float time)
    {
        _maxTime = time;
        ResetTimer(time);
    }

    private void ResetTimer(float time)
    {
        _timer = time;
        _isEndTime = false;
        _slider.value = time / _maxTime;
    }
    
    private void Update()
    {
        if (_isEndTime)
            return;
        
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _timer = 0;
            _isEndTime = true;
            OnEndTime?.Invoke();
        }

        DisplayTimer(_timer);
    }

    private void DisplayTimer(float timeToDisplay)
    {
        if (timeToDisplay < 0)
            timeToDisplay = 0;

        var seconds = Mathf.FloorToInt(timeToDisplay % 60);
        var minutes = Mathf.FloorToInt(timeToDisplay / 60);

        _timerLabel.text = $"{minutes:00}:{seconds:00}";
        _slider.value = timeToDisplay / _maxTime;
    }
}
