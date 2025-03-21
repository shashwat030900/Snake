using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : SnakeController
{
    public override void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && lastDirection != Vector2.down)
            moveDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow) && lastDirection != Vector2.up)
            moveDirection = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && lastDirection != Vector2.right)
            moveDirection = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow) && lastDirection != Vector2.left)
            moveDirection = Vector2.right;

        lastDirection = moveDirection;
    }
}

