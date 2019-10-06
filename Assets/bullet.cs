using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject particle;
    public float lifeTime = 3.0f;
    public int Power = 3;
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
        enemy Enemy = collision.GetComponent<enemy>();
        if (Enemy != null) {
            Enemy.TakeDamage(Power);
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.name != "Player") {
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
