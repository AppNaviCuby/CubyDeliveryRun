using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeath : MonoBehaviour
{
    bool deathflag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(deathflag){

        }
    }

      public void OnTriggerEnter2D(Collider2D other){
           if (other.gameObject.tag == "Character"){
       
       Debug.Log("death");
        StartCoroutine("DeathRetry");
           }
    }

    IEnumerator DeathRetry(){
            //3秒停止

             Time.timeScale = 0.0f;
           SceneManager.LoadScene (SceneManager.GetActiveScene().name);
           yield break;
    }
        
}
