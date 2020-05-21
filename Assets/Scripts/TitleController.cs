using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{

    public GameObject Unitychan;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Invoke("GoToFirstStage", 0.5f);
        }
    }

    void GoToFirstStage()
    {
        SceneManager.LoadScene("StageSelect_nobu");
    }
}