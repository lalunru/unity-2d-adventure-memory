using UnityEngine;

public class PuzzlePieceController : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 originalPos;
    public Transform targetSlot;
    public float snapThreshold = 0.5f;

    private bool isPlaced = false;

    void Start()
    {
        originalPos = transform.position;
    }

    void OnMouseDown()
    {
        if (isPlaced) return;

        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        if (isPlaced) return;

        Vector3 curMouse = GetMouseWorldPos() + offset;
        transform.position = new Vector3(curMouse.x, curMouse.y, 0);
    }

    void OnMouseUp()
    {
        if (isPlaced) return;

        if (Vector3.Distance(transform.position, targetSlot.position) < snapThreshold)
        {
            transform.position = targetSlot.position;
            isPlaced = true;

            // 퍼즐 매니저가 존재하면 퍼즐 완료 체크
            if (FindObjectOfType<PuzzleManager>() != null)
            {
                FindObjectOfType<PuzzleManager>().CheckAllPieces();
            }
        }
        else
        {
            transform.position = originalPos;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10f;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public bool IsPlaced()
    {
        return isPlaced;
    }
}
