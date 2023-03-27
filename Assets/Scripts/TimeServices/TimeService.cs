using System;
using Cysharp.Threading.Tasks;

public abstract class TimeService
{
    public abstract UniTask<TimeSpan> GetTime();
}