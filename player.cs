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
NewEnemy.cs
We'll create a new enemy type with a different behavior. For example, it can move diagonally.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    private float speed = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(1, -1, 0) * Time.deltaTime * speed);

        if (transform.position.y < -8f || transform.position.x > 11.5f || transform.position.x < -11.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
GameManager.cs
We add logic to spawn these different enemies at different rates.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy; // Existing enemy
    public GameObject newEnemy; // New enemy

    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f); // Original enemy
        InvokeRepeating("CreateNewEnemy", 2f, 5f); // New enemy with different spawn time
    }

    void Update()
    {
        
    }

    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 8f, 0), Quaternion.identity);
    }

    void CreateNewEnemy()
    {
        Instantiate(newEnemy, new Vector3(Random.Range(-9f, 9f), 8f, 0), Quaternion.identity);
    }
}
