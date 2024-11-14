using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private float speed;
    private float horizontalScreenLimit;
    private float verticalScreenLimit;
    public GameObject explosion;
    public GameObject bullet;
    public GameObject thrusters;
    public GameObject shield;
    public static int lives;
    private int shooting;
    private bool hasShield;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        horizontalScreenLimit = 11.5f;
        verticalScreenLimit = 7.5f;
        lives = 3;
        shooting = 1;
        hasShield = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch(shooting)
            {
            case 1:
                Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                break;
            
            case 2:
                Instantiate(bullet, transform.position + new Vector3(0.5f, 1, 0), Quaternion.identity);
                Instantiate(bullet, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(bullet, transform.position + new Vector3(0.5f, 1, 0), Quaternion.Euler(0, 0, -30f));
                Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                Instantiate(bullet, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.Euler(0, 0, 30f));
                break;
             }
        }
    }

    public void LoseALife()
    {
        if (hasShield == false)
        {
            lives--;
        } else if (hasShield == true)
        {
            //Lose the Shield if hit with it equipped, no damage.
            hasShield = false;
            shield.gameObject.SetActive(false);
            gameManager.UpdatePowerupText("");
            gameManager.PlayPowerDown();
        }
        //lives = lives - 1;
        //lives -= 1;
        
        // lives--;
        Debug.Log("You lost a life.");
        

        if (lives == 0)
        {
            gameManager.GameOver();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("You ran out of lives!");
        }
    }

IEnumerator SpeedPowerDown()
{
    yield return new WaitForSeconds(3f);
    speed = 6f;
    thrusters.gameObject.SetActive(false);
    gameManager.UpdatePowerupText("");
    gameManager.PlayPowerDown();
}


IEnumerator ShootingPowerDown()
{
    yield return new WaitForSeconds(4f);
    shooting = 1;
    gameManager.UpdatePowerupText("");
    gameManager.PlayPowerDown();
}

IEnumerator ShieldPowerDown()
{
    yield return new WaitForSeconds(5f);
    hasShield = false;
    shield.gameObject.SetActive(false);
    gameManager.UpdatePowerupText("");
    gameManager.PlayPowerDown();
}

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "PowerUp")
        {
            gameManager.PlayPowerUp();
            int powerupType = Random.Range(1, 5); // 4 Power Ups in Total it'll pick from
            switch(powerupType)
            {
                case 1:
                    // speed powerup
                    speed = 9f;
                    gameManager.UpdatePowerupText("Speed Increase!");
                    thrusters.gameObject.SetActive(true);
                    StartCoroutine(SpeedPowerDown());
                    break;
                case 2:
                    // double shot
                    gameManager.UpdatePowerupText("Double Shots!");
                    shooting = 2;
                    StartCoroutine (ShootingPowerDown());
                    break;
                case 3:
                    // triple shot
                    gameManager.UpdatePowerupText("Triple Shots!");
                    shooting = 3;
                    StartCoroutine (ShootingPowerDown());
                    break;
                case 4:
                    // shield
                    gameManager.UpdatePowerupText("Defensive Shield!");
                    hasShield = true;
                    shield.gameObject.SetActive(true);
                    break;
            }
            Destroy(whatDidIHit.gameObject);
        }
    }


}
