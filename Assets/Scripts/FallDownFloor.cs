﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownFloor : MonoBehaviour
{
    //　床が落下するまでの時間
	[SerializeField]private float timeToFall = 1.0f;
    [SerializeField]private float overWeight = 1;

    GameObject TargetManager;
    TargetManager script;
    int unitychanWeight = 0;
     

      Rigidbody2D rb;
      Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        TargetManager = GameObject.Find("TargetManager");
        script = TargetManager.GetComponent<TargetManager>();
         //Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
       rb.isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {
        unitychanWeight = script.weight;
    }

   

     public void OnCollisionEnter2D(Collision2D other){
         Debug.Log(unitychanWeight);
         Debug.Log(overWeight);
         

        if (other.gameObject.tag == "Character" && (unitychanWeight >= overWeight)){
             StartCoroutine("FloorDownCount");
            Debug.Log("in");
            
        }
     }

    public void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag == "Character"){
         StopCoroutine("FloorDownCount");
          
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
