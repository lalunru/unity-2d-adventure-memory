using UnityEngine;

[DisallowMultipleComponent]
public class Interactable : MonoBehaviour
{
    [Header("대화/이동 모드")]
    [Tooltip("체크 시, 대화 없이 즉시 Scene을 로드합니다.")]
    public bool instantLoad = false;

    [Header("대화 내용 (instantLoad = false 일 때)")]
    [TextArea(2, 5)] public string talkData = "여기에 대사 입력";

    [Header("로드할 씬 이름")]
    [Tooltip("Build Settings에 등록된 씬 이름")]
    public string sceneName;
}
