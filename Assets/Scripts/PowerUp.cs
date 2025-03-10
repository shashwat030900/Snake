using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    [SerializeField] public enum PowerUpType { Shield, ScoreBoost, SpeedUp }
    public PowerUpType powerUpType;
    [SerializeField] private float cooldownTime = 3f;
    [SerializeField] private float speedUpFactor = 2f;
    [SerializeField] private int scoreBoostFactor = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ApplyPowerUp(collision.GetComponent<SnakeController>()));
            Destroy(gameObject);
        }
    }

    private IEnumerator ApplyPowerUp(SnakeController snake)
    {
        switch (powerUpType)
        {
            case PowerUpType.Shield:
                snake.ActivateShield();
                break;
            case PowerUpType.ScoreBoost:
                GameManager.Instance.SetScoreBoost(scoreBoostFactor);
                break;
            case PowerUpType.SpeedUp:
                snake.SpeedUp(speedUpFactor);
                break;
        }

        yield return new WaitForSeconds(cooldownTime);

        switch (powerUpType)
        {
            case PowerUpType.Shield:
                snake.DeactivateShield();
                break;
            case PowerUpType.ScoreBoost:
                GameManager.Instance.ResetScoreBoost();
                break;
            case PowerUpType.SpeedUp:
                snake.ResetSpeed();
                break;
        }
    }
}