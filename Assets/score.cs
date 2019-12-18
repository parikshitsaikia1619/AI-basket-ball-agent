
using UnityEngine;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "prefab")
        {
            
            
            Debug.Log("destroyed_ball");
            Destroy(collision.gameObject,2);
        }
     

    }

}    
