using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int glassHitCount = 0;
    public int maxHits = 3;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Glass"))
        {
            glassHitCount++;
            StartCoroutine(FlashPlayer());

            if (glassHitCount >= maxHits)
            {
                GameOver();
            }
        }
    }

    IEnumerator FlashPlayer()
    {
        for (int i = 0; i < 3; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void GameOver()
    {
        Debug.Log("게임 오버!");
        SceneManager.LoadScene("GameOverScene");
    }
}
