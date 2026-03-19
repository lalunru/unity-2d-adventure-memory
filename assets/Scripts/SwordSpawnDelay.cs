using UnityEngine;
using System.Collections;

public class SwordSpawnDelay : MonoBehaviour
{
    public GameObject swordEnemyPrefab;
    public Transform spawnPoint;
    public float delaySeconds = 2f;

    void Start()
    {
        StartCoroutine(SpawnAfterDelay());
    }

    IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(delaySeconds);
        Instantiate(swordEnemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}