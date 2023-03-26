using UnityEngine.SceneManagement;

public static class SceneManagerHelper
{
    public static void LoadMainScene() => SceneManager.LoadScene(1, LoadSceneMode.Single);
}