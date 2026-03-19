using UnityEngine;
using TMPro;
using System;

public class TalkManager : MonoBehaviour
{
    public static TalkManager I;

    [Header("UI 세팅")]
    public Canvas uiCanvas;      // Screen Space–Overlay Canvas
    public GameObject bubblePrefab;  // Bottom-Center 세팅된 Prefab

    GameObject currentBubble;
    bool isOpen = false;
    Interactable currentInteract;

    public static event Action OnDialogOpened;
    public static event Action<Interactable> OnDialogClosed;

    void Awake()
    {
        if (I == null) I = this;
        else Destroy(gameObject);
    }

    /// <summary>
    /// instantLoad=false 인 오브젝트 전용: 대화창 토글
    /// </summary>
    public void Action(Interactable interact)
    {
        if (!isOpen)
        {
            currentInteract = interact;
            currentBubble = Instantiate(bubblePrefab, uiCanvas.transform);
            currentBubble.GetComponentInChildren<TextMeshProUGUI>().text = interact.talkData;
            isOpen = true;
            OnDialogOpened?.Invoke();
        }
        else
        {
            Destroy(currentBubble);
            isOpen = false;
            OnDialogClosed?.Invoke(currentInteract);
        }
    }

    /// <summary>
    /// 강제 닫기
    /// </summary>
    public void Hide()
    {
        if (isOpen)
        {
            Destroy(currentBubble);
            isOpen = false;
            OnDialogClosed?.Invoke(currentInteract);
        }
    }
}
