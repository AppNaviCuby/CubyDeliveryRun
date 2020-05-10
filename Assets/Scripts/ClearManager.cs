using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    public GameObject clearPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameClear()
    {
        clearPanel.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D thisTrigger)
    {
        if(thisTrigger.gameObject.tag =="Character")
        {
            GameClear();
        }
    }
}
