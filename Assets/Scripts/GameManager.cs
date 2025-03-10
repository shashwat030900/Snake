using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject massGainerPrefab;
    public GameObject massBurnerPrefab;
    [SerializeField] private float foodSpawnInterval = 2f;

    public static GameManager Instance;
    private int score = 0;

    public GameObject shieldPrefab;
    public GameObject scoreBoostPrefab;
    public GameObject speedUpPrefab;
    public float powerUpSpawnInterval = 10f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnFood", 1f, foodSpawnInterval);
        InvokeRepeating("SpawnPowerUp", 5f, powerUpSpawnInterval);
    }

    private void SpawnFood()
    {
        
        GameObject foodPrefab = Random.value > 0.5f ? massGainerPrefab : massBurnerPrefab;
        Vector2 spawnPos = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        Instantiate(foodPrefab, spawnPos, Quaternion.identity);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public void DecreaseScore(int amount)
    {
        score -= amount;
        if (score < 0) score = 0; 
        Debug.Log("Score: " + score);
    }

    // For Score boost

    private int scoreMultiplier = 1;

    public void SetScoreBoost(int scoreBoostFactor)
    {
        scoreMultiplier = scoreBoostFactor;
    }

    public void ResetScoreBoost()
    {
        scoreMultiplier = 1;
    }

    
    private void SpawnPowerUp()
    {
    
        int randomPowerUp = Random.Range(0, 3); 

        GameObject powerUpPrefab = null;
        Vector2 spawnPos = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));

        switch (randomPowerUp)
        {
            case 0:
                powerUpPrefab = shieldPrefab;
                break;
            case 1:
                powerUpPrefab = scoreBoostPrefab;
                break;
            case 2:
                powerUpPrefab = speedUpPrefab;
                break;
        }

        if (powerUpPrefab != null)
        {
            Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
        }
    }
}
