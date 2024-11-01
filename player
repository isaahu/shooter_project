using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed;
    public GameObject bullet;

    // Bounds
    private float xBoundary = 11.5f; // Example values
    private float bottomBoundary = -8f; // Example values
    private float middleBoundary;

    void Start()
    {
        speed = 6f;
        middleBoundary = (bottomBoundary + 8f) / 2f; // Assuming 8f is the top of the screen
    }

    void Update()
    {
        Moving();
        Shooting();
    }

    void Moving()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        // Left and right looping
        if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, 0);
        }
        else if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, 0);
        }

        // Top and bottom bound check
        if (transform.position.y > middleBoundary)
        {
            transform.position = new Vector3(transform.position.x, middleBoundary, 0);
        }
        else if (transform.position.y < bottomBoundary)
        {
            transform.position = new Vector3(transform.position.x, bottomBoundary, 0);
        }
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}