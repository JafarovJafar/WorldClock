using System;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

public class TimeApiService : TimeService
{
    private string _url = "https://www.timeapi.io/api/Time/current/coordinate?latitude=48.8534&longitude=2.3488";

    public override async UniTask<TimeSpan> GetTime()
    {
        string some = (await UnityWebRequest.Get(_url).SendWebRequest()).downloadHandler.text;
        Root result = JsonUtility.FromJson<Root>(some);

        int hours = Convert.ToInt32(result.hour);
        int minutes = Convert.ToInt32(result.minute);
        int seconds = Convert.ToInt32(result.seconds);

        TimeSpan resultTime = new TimeSpan(hours, minutes, seconds);

        return resultTime;
    }

    private class Root
    {
        public int year;
        public int month;
        public int day;
        public int hour;
        public int minute;
        public int seconds;
        public string date;
    }
}