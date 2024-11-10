using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int scoreValue = 1; // Score value for each coin collected

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Assuming GameManager has a method to add score
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(scoreValue);

            // Collect the coin (destroy it)
            Destroy(this.gameObject);
        }
    }
}
