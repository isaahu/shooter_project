using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject coin;
    public GameObject cloud;
    public GameObject powerup;

    public AudioClip powerUp;
    public AudioClip powerDown;
    public AudioClip coinGet;

    public int cloudSpeed;

    private int score;

    private bool isPlayerAlive;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI powerUpText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateCoin", 1f, 10f);
        StartCoroutine(CreatePowerup());
        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;
        isPlayerAlive = true;
        cloudSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        int liveCount = Player.lives;
        livesText.text = "Lives: " + liveCount;
        Restart();
    }

    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
    }

    void CreateCoin()
    {
        Instantiate(coin, new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    IEnumerator CreatePowerup()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(powerup, new Vector3(Random.Range(-9f, 9f), Random.Range(-3f, 5f), 0), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(6f, 12f));
        StartCoroutine(CreatePowerup());
    }

    public void EarnScore(int howMuch) 
    {  
        score = score + howMuch;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isPlayerAlive = false;
        CancelInvoke();
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        cloudSpeed = 0;
    }

    void Restart()
    {
        if(Input.GetKeyDown(KeyCode.R)&& isPlayerAlive == false)
        {
            //Restart the Game
            SceneManager.LoadScene("Game");
        }
    }

    public void UpdatePowerupText(string whichPowerUp)
    {
        powerUpText.text = whichPowerUp;
    }

    public void PlayPowerUp()
    {
        AudioSource.PlayClipAtPoint(powerUp, Camera.main.transform.position);
    }

    public void PlayPowerDown()
    {
        AudioSource.PlayClipAtPoint(powerDown, Camera.main.transform.position);
    }

    public void PlayCoinGet()
    {
        AudioSource.PlayClipAtPoint(powerDown, Camera.main.transform.position);
    }

}