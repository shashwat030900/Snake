using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform bodyPrefab;
    [SerializeField] private int initialSnakeSize = 3;

    private Vector2 moveDirection;
    private List<Transform> bodyParts = new List<Transform>();
    private Vector2 lastDirection;

    private bool isShielded = false;
    private float baseSpeed;

    private void Start()
    {
        moveDirection = Vector2.right;
        lastDirection = moveDirection;

        for (int i = 0; i < initialSnakeSize; i++)
        {
            GrowSnake();
        }
    }

    private void Update()
    {
        HandleInput();
        CheckSelfCollision();
    }

    private void FixedUpdate()
    {
        MoveSnake();
        HandleScreenWrap();
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.W) && lastDirection != Vector2.down)
            moveDirection = Vector2.up;
        if (Input.GetKey(KeyCode.S) && lastDirection != Vector2.up)
            moveDirection = Vector2.down;
        if (Input.GetKey(KeyCode.A) && lastDirection != Vector2.right)
            moveDirection = Vector2.left;
        if (Input.GetKey(KeyCode.D) && lastDirection != Vector2.left)
            moveDirection = Vector2.right;

        lastDirection = moveDirection;
    }

    private void MoveSnake()
    {
        Vector2 currentPosition = transform.position;
        Vector2 newPosition = currentPosition + moveDirection * moveSpeed * Time.fixedDeltaTime;

        if (bodyParts.Count > 0)
        {
            for (int i = bodyParts.Count - 1; i > 0; i--)
            {
                bodyParts[i].position = bodyParts[i - 1].position;
            }
            bodyParts[0].position = currentPosition;
        }

        transform.position = newPosition;
    }

    public void GrowSnake()
    {
        Transform bodyPart = Instantiate(bodyPrefab);

        if (bodyParts.Count > 0)
        {
            bodyPart.position = new Vector3(
                (bodyParts[bodyParts.Count - 1].position.x - moveDirection.x),
                (bodyParts[bodyParts.Count - 1].position.y - moveDirection.y),
                bodyParts[bodyParts.Count - 1].position.z);
        }
        else
        {
            bodyPart.position = new Vector3(
                (transform.position.x - moveDirection.x),
                (transform.position.y - moveDirection.y),
                transform.position.z);
        }

        bodyParts.Add(bodyPart);
    }

    private void HandleScreenWrap()
    {
        Vector3 position = transform.position;

        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize;

        if (position.x > screenWidth)
        {
            position.x = -screenWidth;
        }
        else if (position.x < -screenWidth)
        {
            position.x = screenWidth;
        }

        if (position.y > screenHeight)
        {
            position.y = -screenHeight;
        }
        else if (position.y < -screenHeight)
        {
            position.y = screenHeight;
        }

        transform.position = position;
    }

    private void CheckSelfCollision()
    {
        for (int i = 1; i < bodyParts.Count; i++)
        {
            if ((Vector2)transform.position == (Vector2)bodyParts[i].position)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if (!isShielded)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }

    public void ActivateShield()
    {
        isShielded = true;
    }

    public void DeactivateShield()
    {
        isShielded = false;
    }

    public void SpeedUp(float speedUpFactor)
    {
        if (baseSpeed == 0) baseSpeed = moveSpeed;
        moveSpeed *= speedUpFactor;
    }

    public void ResetSpeed()
    {
        if (baseSpeed != 0) moveSpeed = baseSpeed;
    }
    public void ShrinkSnake()
    {
        if (bodyParts.Count > 1) 
        {
            Transform lastPart = bodyParts[bodyParts.Count - 1];
            bodyParts.Remove(lastPart);
            Destroy(lastPart.gameObject);
        }
    }

}