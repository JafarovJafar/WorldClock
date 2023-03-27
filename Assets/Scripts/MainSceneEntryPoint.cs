using UnityEngine;

public class MainSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private TimeFetcher _timeFetcher;
    [SerializeField] private Clock _clock;
    
    private void Start()
    {
        _timeFetcher.Init();
        _clock.Init();
    }
}