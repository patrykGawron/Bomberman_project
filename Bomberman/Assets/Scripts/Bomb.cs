using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float lifetime = 4.3f;
    void Update()
    {
        lifetime -= Time.deltaTime;

        if(lifetime <= 0 )
        {
            FindObjectOfType<WallDestroyer>().Explode(transform.position);
            Destroy(gameObject);
        }
    }
}
