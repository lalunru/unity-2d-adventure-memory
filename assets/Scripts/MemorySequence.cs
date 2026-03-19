using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MemorySequence : MonoBehaviour
{
    public GameObject memoryPanel;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public float textDelay = 2f;
    public float endDelay = 1.5f;
    public string nextSceneName = "Day2_Scene";

    void Start()
    {

        Debug.Log("¢∫ MemorySequence Ω√¿€µ ");
        StartCoroutine(PlayMemory());
    }

    IEnumerator PlayMemory()
    {
        memoryPanel.SetActive(true);

        text1.gameObject.SetActive(true);
        yield return new WaitForSeconds(textDelay);

        text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(textDelay + endDelay);

        SceneManager.LoadScene(nextSceneName);
    }
}