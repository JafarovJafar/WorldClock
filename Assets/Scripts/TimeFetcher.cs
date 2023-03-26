using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeFetcher : MonoBehaviour
{
    [SerializeField] private float _fetchInterval = 7200;

    private List<TimeService> _services;

    private float _currentTime;

    private List<TimeSpan> _lastTimeSpans = new List<TimeSpan>();

    public void Init()
    {
        _services = new List<TimeService>();
        _services.Add(new TimeZoneApiService());
        _services.Add(new TimeApiService());
    }

    private async void Fetch()
    {
        _lastTimeSpans.Clear();
        
        foreach (var service in _services)
        {
            _lastTimeSpans.Add(await service.GetTime());
        }

        foreach (var timeSpan in _lastTimeSpans)
        {
            Debug.Log(timeSpan);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) Fetch();

        return;
        
        if (_currentTime < _fetchInterval)
        {
            _currentTime += Time.deltaTime;
            return;
        }

        _currentTime = 0f;
        Fetch();
    }
}