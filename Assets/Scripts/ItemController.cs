using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    TargetManager targetManager;
    // Start is called before the first frame update
    void Start()
    {
        targetManager = GameObject.Find("TargetManager").GetComponent<TargetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D thisCollision)
    {
        if(thisCollision.gameObject.tag == "Character")
        {
            targetManager.weight = 1;
            Destroy(this.gameObject);
        }
    }
}
