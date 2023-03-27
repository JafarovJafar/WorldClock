using System;
using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private ClockArrow _hourArrow;
    [SerializeField] private ClockArrow _minutesArrow;
    [SerializeField] private ClockArrow _secondsArrow;

    private WaitForSeconds _secondsWFS;
    
    public void Init()
    {
        _hourArrow.Init(24);
        _minutesArrow.Init(60);
        _secondsArrow.Init(60);

        _secondsArrow.LapCompleted += SecondsArrow_Completed;
        _minutesArrow.LapCompleted += MinutesArrow_Completed;

        _secondsWFS = new WaitForSeconds(1f);
        
        StartCoroutine(MainCoroutine());
    }

    public void SetActualTime(TimeSpan timeSpan)
    {
        _hourArrow.SetCurrent(timeSpan.Hours);
        _minutesArrow.SetCurrent(timeSpan.Minutes);
        _secondsArrow.SetCurrent(timeSpan.Seconds);
    }

    private IEnumerator MainCoroutine()
    {
        while (true)
        {
            yield return _secondsWFS;
            _secondsArrow.Increase();
        }
    }

    private void SecondsArrow_Completed() => _minutesArrow.Increase();
    private void MinutesArrow_Completed() => _hourArrow.Increase();
}