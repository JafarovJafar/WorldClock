using System;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

public class TimeZoneApiService : TimeService
{
    private string _url = "https://timezoneapi.io/api/timezone/?Europe/Paris&token=aPgnlzyvqzAFZJrKimKJ";

    public override async UniTask<TimeSpan> GetTime()
    {
        string some = (await UnityWebRequest.Get(_url).SendWebRequest()).downloadHandler.text;
        Root result = JsonUtility.FromJson<Root>(some);

        int hours = Convert.ToInt32(result.data.datetime.hour_24_wilz);
        int minutes = Convert.ToInt32(result.data.datetime.minutes);
        int seconds = Convert.ToInt32(result.data.datetime.seconds);

        TimeSpan resultTime = new TimeSpan(hours, minutes, seconds);

        return resultTime;
    }

    [Serializable]
    public class Root
    {
        public Data data;
    }

    [Serializable]
    public class Data
    {
        public Datetime datetime;
    }

    [Serializable]
    public class Datetime
    {
        public string date;
        public string time;
        public string day;
        public string hour_24_wilz;
        public string minutes;
        public string seconds;
    }
}