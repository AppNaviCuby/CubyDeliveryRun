﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    TargetManager targetManager;

    // Start is called before the first frame updat
    void Start()
    {
        targetManager = GameObject.Find("TargetManager").GetComponent<TargetManager>();

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

     void OnCollisionEnter2D(Collision2D thisCollision)
    {
        Sprite thisFood = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        //衝突判定
        if (thisCollision.gameObject.tag == "Character" )
        {   
            targetManager.gravityAdd(targetManager.weight + 1);
            //当たった時にtargetListと比較し正誤判定
            //Debug.Log("判定開始");
            targetManager.targetJudge(thisFood);
            //Debug.Log("判定終了");

            //sound1鳴らす
            audioSource.PlayOneShot(audioClip[0]);
            //判定後重さ+1して自分を消す
            Destroy(this.gameObject);
        }
    }
}

