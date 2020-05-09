using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownFloor : MonoBehaviour
{
    //　床が落下するまでの時間
	[SerializeField]
	private float timeToFall = 1.0f;

      Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
         //Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
       rb.isKinematic = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Character"){
             StartCoroutine("FloorDownCount");
        }
     }

    public void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag == "Character"){
         StopCoroutine("FloorDownCount");
         Debug.Log("out");
        }
    }

      IEnumerator FloorDownCount()
    {//３秒経過後に回転する
        yield return new WaitForSeconds(timeToFall);
         rb.isKinematic = false;
    }
}
