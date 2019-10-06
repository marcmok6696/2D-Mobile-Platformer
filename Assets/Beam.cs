using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float lifeTime = 3.0f;
    public int Power = 10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerController>().GetDamaged(Power);
            Destroy(gameObject);
        }

    }
}
