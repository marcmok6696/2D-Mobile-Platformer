using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapControl : MonoBehaviour
{
    public float speed = 5.0f;
    private bool moveRight;
    public float distance = 5.0f;
    public GameObject beam;
    public Transform beamPos;
    public float beamSpeed = 10f;
    public Transform groundDetection;
    private float timeBtwShot;
    public float startTimeBtwShot = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null && hitInfo.collider.tag=="Player")
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            if (timeBtwShot <= 0)
            {
                Shoot();
            }
            else {
                timeBtwShot -= Time.deltaTime;
            }
  

        }
        else {
            Move();
            Debug.DrawLine(transform.position, transform.position+ transform.right*distance, Color.green);

        }

        
    }

    void Shoot() {
        GameObject Beam = Instantiate(beam, beamPos.position, transform.rotation);
        if (transform.localScale.x < -0.1)
        {
            Beam.GetComponent<Rigidbody2D>().velocity = transform.right * -1 * beamSpeed;
        }
        else if (transform.localScale.x >= 0.1)
        {
            Beam.GetComponent<Rigidbody2D>().velocity = transform.right * beamSpeed;
        }
        timeBtwShot = startTimeBtwShot;
    }

    void Move() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            if (moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }
}
