using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    public LogicScript logic;
    public bool isAlive = true;

    Rigidbody2D rb;
    float movement = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        logic = FindObjectOfType<LogicScript>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        float levelWidth = 3f;

        // Screen Wrapping logic
        if (transform.position.x > levelWidth)
            transform.position = new Vector3(-levelWidth, transform.position.y, transform.position.z);
        else if (transform.position.x < -levelWidth)
            transform.position = new Vector3(levelWidth, transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        // Apply Movement
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // This checks if the object we hit has the Tag "DeadZone"
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            logic.GameOver();
            isAlive = false;
            gameObject.SetActive(false); // Hides the player
        }
    }
}