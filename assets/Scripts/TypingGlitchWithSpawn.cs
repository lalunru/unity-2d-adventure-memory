using System.Collections;
using UnityEngine;
using TMPro;

public class TypingGlitchWithSpawn : MonoBehaviour
{
    public TextMeshProUGUI glitchText;
    public string repeatPhrase = "기억하고 싶지 않아.";
    public int repeatCount = 20;
    public float startDelay = 0.5f;
    public float typeSpeed = 0.04f;
    public float acceleration = 0.003f;
    public int glitchStartAt = 10;

    public GameObject swordEnemyPrefab;
    public Transform spawnPoint;

    private string glitchCharset = "█▇▆▅▃▂■▒※✖▣▤▦";

    void Start()
    {
        StartCoroutine(TypeAndSpawn());
    }

    IEnumerator TypeAndSpawn()
    {
        glitchText.text = "";
        yield return new WaitForSeconds(startDelay);

        for (int i = 0; i < repeatCount; i++)
        {
            string current = repeatPhrase;

            // i가 glitchStartAt 이상이면 글자 중 일부 깨뜨림
            if (i >= glitchStartAt)
            {
                char[] chars = current.ToCharArray();
                for (int j = 0; j < chars.Length; j++)
                {
                    if (Random.value < 0.3f) // 30% 확률로 깨진 문자
                    {
                        chars[j] = glitchCharset[Random.Range(0, glitchCharset.Length)];
                    }
                }
                current = new string(chars);
            }

            // 한 글자씩 출력
            foreach (char c in current)
            {
                glitchText.text += c;
                yield return new WaitForSeconds(typeSpeed);
            }

            glitchText.text += "\n";

            // 가속
            if (typeSpeed > 0.005f)
                typeSpeed -= acceleration;
        }

        // 적 등장
        Instantiate(swordEnemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
