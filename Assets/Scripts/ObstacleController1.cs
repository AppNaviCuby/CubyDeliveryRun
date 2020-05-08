using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    Rigidbody2D rb2d = new Rigidbody2D();

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
        //rigidbody2D.velocity = Vector2.zero;
        //rigidbody2D.angularVelocity = 0f;
    }

    void OnCollisionStay2D(Collision2D thisCollision)
    {
        Debug.Log("触れてる");
        if (thisCollision.gameObject.tag == "Character" )
        {
            Debug.Log("キャラに触れた");
            //rigidbody取得
            rb2d = this.GetComponent<Rigidbody2D>();
            Vector2 moveVector = new Vector2(0f, 1.0f);

            //押した方向に応じて移動
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("動く");
                rb2d.AddForce(moveVector * 1.0f);
            }
            

            //horizonalStop();
            Debug.Log("静止");
        }
       
        
    }
}
