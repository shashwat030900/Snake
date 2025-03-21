using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : SnakeController
{
    public override void HandleInput()
{
    if (Input.GetKey(KeyCode.W) && lastDirection != Vector2.down)
        moveDirection = Vector2.up;
    else if (Input.GetKey(KeyCode.S) && lastDirection != Vector2.up)
        moveDirection = Vector2.down;
    else if (Input.GetKey(KeyCode.A) && lastDirection != Vector2.right)
        moveDirection = Vector2.left;
    else if (Input.GetKey(KeyCode.D) && lastDirection != Vector2.left)
        moveDirection = Vector2.right;

    lastDirection = moveDirection;
}

}
