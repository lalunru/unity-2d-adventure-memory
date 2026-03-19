using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneSignalHandler : MonoBehaviour
{
    public string sceneToLoad; // Inspector에서 설정할 씬 이름

    public void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name is empty. Please set 'sceneToLoad' in the Inspector.");
        }
    }
}
