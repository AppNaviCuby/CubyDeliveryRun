using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageScript : MonoBehaviour {

    public int stage_num; // スコア変数
    
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;
    public GameObject ten;
    public GameObject eleven;
    public GameObject twelve;
    public GameObject thirteen;
    public GameObject fourteen;
    public GameObject fifteen;
    
    public GameObject two_;
    public GameObject three_;
    public GameObject four_;
    public GameObject five_;
    public GameObject six_;
    public GameObject seven_;
    public GameObject eight_;
    public GameObject nine_;
    public GameObject ten_;
    public GameObject eleven_;
    public GameObject twelve_;
    public GameObject thirteen_;
    public GameObject fourteen_;
    public GameObject fifteen_;
    
    
 

    // Use this for initialization
    void Start () {
        //現在のstage_numを呼び出す
      stage_num= PlayerPrefs.GetInt ("SCORE", 0);                                                                                                                                                                                                                                                                                                                              
      
    }

    // Update is called once per frame
    void Update () {
        //stage_numが２以上のとき、ステージ２を解放する。以下同様
        
            
   if(Input.GetKey("r")) {
		stage_num=0;
	}

        Debug.Log(stage_num);
       
        if (stage_num >= 2) {
            two.SetActive (true);
            two_.SetActive(false);
        }

        if (stage_num >= 3) {
            three.SetActive (true);
            three_.SetActive(false);
        
        }

        if (stage_num >= 4) {
            four.SetActive (true);
            four_.SetActive(false);
        }
         if (stage_num >= 5) {
            five.SetActive(true);
            five_.SetActive(false);
        }

        if (stage_num >= 6) {
            six.SetActive (true);
            six_.SetActive(false);
        }

        if (stage_num >= 7) {
            seven.SetActive (true);
            seven_.SetActive(false);
        
        }

        if (stage_num >= 8) {
            eight.SetActive (true);
            eight_.SetActive(false);
        }
          if (stage_num >= 9) {
            nine.SetActive(true);
            nine_.SetActive(false);
        }

        if (stage_num >=10) {
            ten.SetActive (true);
            ten_.SetActive(false);
        }

        if (stage_num >=11) {
            eleven.SetActive (true);
            eleven_.SetActive(false);
        
        }

        if (stage_num >= 12) {
            twelve.SetActive (true);
            twelve_.SetActive(false);
        }
          if (stage_num >= 13) {
            thirteen.SetActive(true);
            thirteen_.SetActive(false);
        }

        if (stage_num >= 14) {
            fourteen.SetActive (true);
            fourteen_.SetActive(false);
        }

        if (stage_num >= 15) {
            fifteen.SetActive (true);
            fifteen_.SetActive(false);
        
        }

       
    }
}