using UnityEngine;

public class Food : MonoBehaviour
{
    private bool isMassGainer = true;
    [SerializeField] private int massChangeAmount = 1;
    [SerializeField] private float destroyTime = 5f;

    private void Start()
    {
        Destroy(gameObject, destroyTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Food Trigger Entered with: " + collision.gameObject.name);
        if (collision.CompareTag("Player"))
        {
            SnakeController snake = collision.GetComponent<SnakeController>();

            if (isMassGainer)
            {
                for (int i = 0; i < massChangeAmount; i++)
                {
                    snake.GrowSnake();
                }
                GameManager.Instance.IncreaseScore(massChangeAmount);
            }
            else
            {
                for (int i = 0; i < massChangeAmount; i++)
                {
                    snake.ShrinkSnake();
                }
                GameManager.Instance.DecreaseScore(massChangeAmount);
            }

            Destroy(gameObject);
        }
    }
}
