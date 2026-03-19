using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider2D))]
public class TextUI: MonoBehaviour
{
    [Header("UI 세팅")]
    public Canvas uiCanvas;             // Screen Space - Overlay Canvas
    public GameObject bubblePrefab;     // 말풍선 Prefab (Image + 텍스트)

    [Header("대화 내용")]
    [TextArea] public string message = "문이 잠겨 있어…";

    [Header("위치 오프셋")]
    public Vector3 worldOffset = new Vector3(0, 1f, 0);    // 문 위 월드 오프셋
    public Vector2 screenOffset = new Vector2(0, 10f);     // 로컬(anchored) 오프셋

    private GameObject bubbleInstance;

    void OnMouseDown()
    {
        if (bubbleInstance == null) ShowBubble();
        else HideBubble();
    }

    private void ShowBubble()
    {
        // 1) 인스턴스화
        bubbleInstance = Instantiate(bubblePrefab, uiCanvas.transform);

        // 2) 텍스트 세팅
        bubbleInstance.GetComponentInChildren<TextMeshProUGUI>().text = message;

        // 3) 화면 좌표 → 캔버스 로컬 좌표로 변환
        RectTransform canvasRect = uiCanvas.GetComponent<RectTransform>();
        RectTransform bubbleRect = bubbleInstance.GetComponent<RectTransform>();

        // 월드 포지션 → 스크린 포지션
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + worldOffset);

        // 스크린 → 캔버스 로컬
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            screenPos,
            uiCanvas.renderMode == RenderMode.ScreenSpaceOverlay
                ? null
                : uiCanvas.worldCamera,
            out localPos
        );

        // 4) 최종 배치
        bubbleRect.anchoredPosition = localPos + screenOffset;
    }

    private void HideBubble()
    {
        Destroy(bubbleInstance);
        bubbleInstance = null;
    }
}
