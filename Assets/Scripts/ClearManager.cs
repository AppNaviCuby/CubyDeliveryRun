using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    public GameObject clearPanel,tutorialPanel;
    AudioController audioController;
   public int stage_num;
    //public GameObject MenuPanel;

    // Start is called before the first frame update
    void Start()
    {
   stage_num= PlayerPrefs.GetInt ("SCORE", 0);
       Debug.Log(stage_num);
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    // Update is called once per frame

/*　
void MenuConsole()
    {
        MenuPanel.SetActive(true);
    }
    */
    string[] StageList = new string[15] { "weightStage", "ItemStage", "PushStage", "kuzureruStage", "Stage1"
    ,"Nobu_Stage1","hiroStage","Stage_naru","Guchi_Stage2","Stage_naru3","Nobu_Stage2","Stage_naru2","Guchi_Stage1","hiro2stage","Guchi_Stage3" };

    void OnTriggerEnter2D(Collider2D thisTrigger)
    {
        if(thisTrigger.gameObject.tag =="Character")
        {
            audioController.ClearSound();
            if(tutorialPanel != null)
            {
                tutorialPanel.SetActive(false);
            }
            clearPanel.SetActive(true);
             
              for(int i=0;i<15;i++){
            if(SceneManager.GetActiveScene().name==StageList[i]){
                if(stage_num<=i+2){
                PlayerPrefs.SetInt ("SCORE", i+2);
            //PlayerPrefsをセーブする         
            PlayerPrefs.Save ();
                }
            Debug.Log(i+2);
            }
             
              }
        }
    
    }

     /*
     void Update()
    {
         if (Input.GetKeyDown(KeyCode.A)) {
           　　MenuConsole();
            
        }
    }
    */
}
