using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public float DestoryTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, DestoryTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
