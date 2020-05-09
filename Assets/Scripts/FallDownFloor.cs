using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownFloor : MonoBehaviour
{
    //　床が落下するまでの時間
	[SerializeField]private float timeToFall = 1.0f;
     [Header("振動幅")] public float vibrationWidth = 0.05f;
     [Header("振動速度")] public float vibrationSpeed = 30.0f;

       private bool downFloorFlag = false;
     

      Rigidbody2D rb;
      Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
         //Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
       rb.isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {
     
    }

   

     public void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Character"){
             StartCoroutine("FloorDownCount");
             downFloorFlag = true;
            
        }
     }

    public void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag == "Character"){
         StopCoroutine("FloorDownCount");
          downFloorFlag = false;
         Debug.Log("out");
        }
    }

      IEnumerator FloorDownCount()
    {//指定秒経過後に落ちる
        yield return new WaitForSeconds(timeToFall);
         rb.isKinematic = false;
        col.isTrigger = true;
    }

     void OnBecameInvisible (){
        GameObject.Destroy(this.gameObject);
    }

}
