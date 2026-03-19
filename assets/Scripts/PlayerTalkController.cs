using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PlayerTalkController : MonoBehaviour
{
    Interactable currentInteractable;

    //void Awake()
    //{
    //    // 플레이어 트리거용 콜라이더 + 키네마틱 리지드바디
    //    var col = GetComponent<Collider2D>();
    //    col.isTrigger = true;
    //    var rb = GetComponent<Rigidbody2D>();
    //    rb.bodyType = RigidbodyType2D.Kinematic;
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInteractable != null)
        {
            if (currentInteractable.instantLoad)
            {
                // 즉시 씬 로드
                SceneManager.LoadScene(currentInteractable.sceneName);
            }
            else
            {
                // 대화 모드
                TalkManager.I.Action(currentInteractable);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var i = other.GetComponent<Interactable>();
        if (i != null) currentInteractable = i;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var i = other.GetComponent<Interactable>();
        if (i != null && i == currentInteractable)
        {
            // 범위 벗어나면 대화창 닫기
            TalkManager.I.Hide();
            currentInteractable = null;
        }
    }
}
