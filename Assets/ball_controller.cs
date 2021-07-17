using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ball_controller : MonoBehaviour
{
    public GameObject bball;
    public Transform ballpos;
    public Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball = (GameObject)Instantiate(bball, ballpos.position, ballpos.rotation);
            ball.GetComponent<Rigidbody>().AddForce(-force.x,force.y,force.z);


            //newball.GetComponent<Rigidbody>().AddForce(100, 100, 0);
        }

       if(ballpos.position.y<-3)
        {
            Destroy(bball);
        }
    }
}
