using UnityEngine;

public class Preloader : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("аналитика инициализирована");
        
        SceneManagerHelper.LoadMainScene();
    }
}