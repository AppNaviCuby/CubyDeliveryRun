using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThornController : MonoBehaviour
{
     //変数を作る
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
         //Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){

    }
}
