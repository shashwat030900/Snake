using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    private GameObject massGainerPrefab;
    private GameObject massBurnerPrefab;
    [SerializeField]private float foodSpawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnFood", 1f, foodSpawnInterval);
    }

    void SpawnFood()
    {
        GameObject foodPrefab = Random.value > 0.5f ? massGainerPrefab : massBurnerPrefab;
        Vector2 spawnPos = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        Instantiate(foodPrefab, spawnPos, Quaternion.identity);
    }
}