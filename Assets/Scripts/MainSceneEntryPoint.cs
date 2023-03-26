using UnityEngine;

public class MainSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private TimeFetcher _timeFetcher;
    
    private void Start()
    {
        _timeFetcher.Init();
    }
}