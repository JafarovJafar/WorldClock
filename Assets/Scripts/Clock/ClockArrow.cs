using System;
using UnityEngine;

public class ClockArrow : MonoBehaviour
{
    public event Action LapCompleted;

    private int _currentValue;
    private int _maxValue;

    private Vector3 _eulerAngles;
    private Transform _transform;

    public void Init(int maxValue)
    {
        _eulerAngles = new Vector3();
        _transform = transform;

        _maxValue = maxValue;
        UpdateView();
    }

    public void SetCurrent(int current)
    {
        _currentValue = current;
        UpdateView();

        if (_currentValue == _maxValue)
        {
            _currentValue = _maxValue;
            LapCompleted?.Invoke();
        }
    }

    public void Increase()
    {
        SetCurrent(_currentValue + 1);
    }

    private void UpdateView()
    {
        _eulerAngles.z = -360f / _maxValue * _currentValue;
        _transform.eulerAngles = _eulerAngles;
    }
}