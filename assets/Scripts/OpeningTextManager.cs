using UnityEngine;

public class OpeningTextManager : MonoBehaviour
{
    public GameObject openingPanel;       // 전체 UI 패널
    public GameObject line1Text;          // 첫 번째 대사 오브젝트
    public GameObject line2Text;          // 두 번째 대사 오브젝트
    public OnKeyPress_Move playerMovementScript; // 👈 여기만 타입 바뀜

    private int currentLine = 0;
    private bool isWaiting = true;

    void Start()
    {
        openingPanel.SetActive(true);
        line1Text.SetActive(true);
        line2Text.SetActive(false);
        playerMovementScript.enabled = false; // 조작 비활성화
    }

    void Update()
    {
        if (!isWaiting) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            currentLine++;

            if (currentLine == 1)
            {
                line1Text.SetActive(false);
                line2Text.SetActive(true);
            }
            else if (currentLine == 2)
            {
                openingPanel.SetActive(false);
                playerMovementScript.enabled = true; // 조작 가능
                isWaiting = false;
            }
        }
    }
}
