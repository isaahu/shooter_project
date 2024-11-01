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
