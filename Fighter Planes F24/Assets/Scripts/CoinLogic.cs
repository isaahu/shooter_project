using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    public int myType;
    private float coinLifespan = 5f; // Lifetime of the coin in seconds
    private float coinTimer; // Timer to track how long the coin has been active

    // Start is called before the first frame update
    void Start()
    {
        coinTimer = coinLifespan; // Initialize timer with the lifespan of the coin
    }

    // Update is called once per frame
    void Update()
    {
        // Check if this object is a coin
        if (myType == 4)
        {
            // Reduce coin timer by the passed time since last frame
            coinTimer -= Time.deltaTime;

            // If coin timer reaches zero, destroy the coin
            if (coinTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    
    }
}