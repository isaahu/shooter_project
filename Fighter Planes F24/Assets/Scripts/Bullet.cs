//Isabella Ahumada
//Gabriel Castaneria

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 10f);

        if (transform.position.y > 8f)
        {
            Destroy(this.gameObject);
        }
    }
}