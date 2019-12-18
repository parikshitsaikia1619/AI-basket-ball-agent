using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour   
{
    public Rigidbody rb;
    public float f_force = 500;
    public Transform t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(-f_force * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(f_force * Time.deltaTime, 0, 0);
        }

    }
}
