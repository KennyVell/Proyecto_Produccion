using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public bool canMove = true;
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private Joystick joystick;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (canMove == true)
        {
            float moveH = joystick.Horizontal * moveSpeed;
            float moveV = joystick.Vertical * moveSpeed;
            rb.velocity = new Vector2(moveH, moveV);

            Vector2 direction = new Vector2(moveH, moveV);

            FindObjectOfType<Animation>().SetDirection(direction);
        }
        else
        {
            FindObjectOfType<Animation>().SetDirection(new Vector2(0f, 0f));
            rb.velocity = new Vector2(0f, 0f);
        }
    }
}
