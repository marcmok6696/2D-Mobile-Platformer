using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int Health = 5;
    public int Power = 5;
    public GameObject DieParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void TakeDamage(int damage) {

        Health = Health - damage;

        if (Health <= 0)
        {
            Dead();
        }

    }

    public void Dead() {
        Instantiate(DieParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
