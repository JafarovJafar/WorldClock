using System;
using Cysharp.Threading.Tasks;

public class TimeApiService : TimeService
{
    public override UniTask<TimeSpan> GetTime()
    {
        //UnityWebRequest.Get()
        return new UniTask<TimeSpan>();
    }
}