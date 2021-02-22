using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AllClear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    public void OnClick(){
    PlayerPrefs.SetInt ("SCORE", 10);
    PlayerPrefs.Save ();
    }
}