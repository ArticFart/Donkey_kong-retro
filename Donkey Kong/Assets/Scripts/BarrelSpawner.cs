            using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject barrelPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 5f;

    private float spawnTimer;

    private void Start()
    {
        if (barrelPrefab == null)
        {
            enabled = false;
            return;
        }

        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnBarrel();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnBarrel()
    {
        Vector3 pos = spawnPoint != null ? spawnPoint.position : transform.position;
        Instantiate(barrelPrefab, pos, Quaternion.identity);
    }
}
