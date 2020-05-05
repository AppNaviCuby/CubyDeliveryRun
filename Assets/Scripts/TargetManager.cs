using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    public List<GameObject> targetList = new List<GameObject>();
    public List<Sprite> targetSpriteList = new List<Sprite>();
    public int longth, falseNumber;
    public Text falseText;

    // Start is called before the first frame update
    void Start()
    {
        falseNumber = 0;
        falseText.text = "失敗数　：" +falseNumber+ "回";
        longth = targetList.Count;
        for(int i=0;i < longth;i++)
        {
            targetSpriteList.Add(targetList[i].GetComponent<Image>().sprite);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void targetJudge(Sprite thisFood)
    {
        for(int i = 0; i < longth + 1; i++)
        {
            //判定が正の時、それに応じたアイコンを光らせる
            //Debug.Log(i+1+ "回目");
            if(i == longth)
            {
                falseNumber++;
                break;
            }
            if(thisFood == targetSpriteList[i])
            {
                //Debug.Log("good");
                targetList[i].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            }
        }

        Debug.Log(falseNumber+ "回間違えた");
        falseText.text = "失敗数　：" +falseNumber+ "回";
    }
}
