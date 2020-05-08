using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void horizonalStop()
    {
        //Rigidbody2D.velocity = Vector2.zero;
        //Rigidbody2D.angularVelocity = 0f;
    }

    void OnCollisionEnter2D(Collision2D thisCollision)
    {
        if (thisCollision.gameObject.tag == "Character" )
        {
            Debug.Log("離れた");
        }
       
        
    }
}
