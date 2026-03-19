using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class SceneLoader : MonoBehaviour
{
    [Tooltip("대화 모드 완전 종료 시(스페이스 두 번째) 로드할 씬")]
    public string sceneName;

    void OnEnable()
    {
        TalkManager.OnDialogClosed += HandleClosed;
    }

    void OnDisable()
    {
        TalkManager.OnDialogClosed -= HandleClosed;
    }

    void HandleClosed(Interactable interact)
    {
        // 대화 모드였던 대상과 동일한 오브젝트라면 씬 전환
        if (interact != null && interact.gameObject == this.gameObject)
        {
            if (!string.IsNullOrEmpty(sceneName))
                SceneManager.LoadScene(sceneName);
        }
    }
}
