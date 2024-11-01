using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemy1Prefab; // First enemy type
    public GameObject enemy2Prefab; // Second enemy type

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerPrefab, new Vector3(0, -6, 0), Quaternion.identity);
        InvokeRepeating("CreateEnemyType1", 1f, 3f); // Spawns first enemy type every 3 seconds
        InvokeRepeating("CreateEnemyType2", 5f, 7f); // Spawns second enemy type every 7 seconds
    }

    void CreateEnemyType1()
    {
        Instantiate(enemy1Prefab, new Vector3(Random.Range(-9f, 9f), 8f, 0), Quaternion.identity);
    }

    void CreateEnemyType2()
    {
        Instantiate(enemy2Prefab, new Vector3(Random.Range(-9f, 9f), 8f, 0), Quaternion.identity);
    }
	
    public void Update()
    {
        PlayerMovement();
    }
	
    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        player.transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * 10.0f);

        // Wrap horizontal movement
        if (player.transform.position.x > 11.5f || player.transform.position.x <= -11.5f)
        {
            player.transform.position = new Vector3(player.transform.position.x * -1, player.transform.position.y, 0);
        }

        // Restrict vertical movement to the bottom half of the screen (-8 to 0)
        player.transform.position = new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y, -8f, 0f), 0);
    }

    public class EnemyBehavior
    {
        private GameObject enemy;
        private float speed;

        public EnemyBehavior(GameObject enemy, float speed)
        {
            this.enemy = enemy;
            this.speed = speed;
        }

        public void UpdateMovement()
        {
            enemy.transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (enemy.transform.position.y < -8f)
            {
                Object.Destroy(enemy);
            }
        }
    }

    public class EnemyType2Behavior
    {
        private GameObject enemy;
        private float speed;

        public EnemyType2Behavior(GameObject enemy, float speed)
        {
            this.enemy = enemy;
            this.speed = speed;
        }

        public void UpdateMovement()
        {
            enemy.transform.Translate(new Vector3(Mathf.Sin(Time.time * 2f), -1, 0) * Time.deltaTime * speed);

            if (enemy.transform.position.y < -8f)
            {
                Object.Destroy(enemy);
            }
        }
    }

    public class Bullet
    {
        private GameObject bullet;
        private float speed = 20f;

        public Bullet(GameObject bullet)
        {
            this.bullet = bullet;
        }

        public void UpdateMovement()
        {
            bullet.transform.Translate(Vector3.up * speed * Time.deltaTime);

            if (bullet.transform.position.y > 8f)
            {
                Object.Destroy(bullet);
            }
        }
    }
}