//Isabella Ahumada
//Gabriel Castaneria

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
        transform.Translate(new Vector3 (-1, 0, 0) * Time.deltaTime * speed);

        if (transform.position.y < -8f || transform.position.x > 11.5f || transform.position.x < -11.5f)
        {
            Destroy(this.gameObject);
        }
    }
}