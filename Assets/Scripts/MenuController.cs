using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    
    public GameObject MenuPanel;

    // Start is called before the first frame update
   

    // Update is called once per frame
    
    

　void MenuConsole()
    {
        MenuPanel.SetActive(true);
    }
   
     void Update()
    {
         if (Input.GetKeyDown(KeyCode.T)) {
           　　MenuConsole();
            
        }
    }
}

