using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public void OnTriggerEnter2D(Collider2D other){
           if (other.gameObject.tag == "Character"){

       Debug.Log("death");
       SceneManager.LoadScene (SceneManager.GetActiveScene().name);
           }
    }
}
