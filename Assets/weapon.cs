using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float timeBtwShot;
    public float startTimeBtwShot;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator =gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShot <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("isShoot", true);
                shot();
            }
        }
        else {
            timeBtwShot -= Time.deltaTime;
            animator.SetBool("isShoot", false);
        }
    }
    void shot()
    {
        GameObject clone;
        float speed = 20.0f;
        clone = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if (transform.localScale.x < -0.1) {
            clone.GetComponent<Rigidbody2D>().velocity = transform.right*-1 * speed;
        }
        else if(transform.localScale.x >= 0.1){
            clone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
        timeBtwShot = startTimeBtwShot;
 
    }
}
