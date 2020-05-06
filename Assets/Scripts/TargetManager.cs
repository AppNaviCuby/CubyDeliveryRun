using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    public List<GameObject> targetList = new List<GameObject>();
    public List<Sprite> targetSpriteList = new List<Sprite>();
    public int longth, weight;
    public Text weightText;
    MoveCharacterAction moveCharacterAction;

    // Start is called before the first frame update
    void Start()
    {
        moveCharacterAction = GameObject.FindGameObjectWithTag("Character").GetComponent<MoveCharacterAction>();

        weight = 1;
        weightText.text = "重さ　：" +weight;
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
        for(int i = 0; i < longth; i++)
        {
            if(thisFood == targetSpriteList[i])
            {
                //Debug.Log("good");
                targetList[i].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            }
        }

        //Debug.Log(falseNumber+ "回間違えた");
        weightText.text = "重さ　：" +weight;
    }
    public int gravityAdd()
    {
        weight++;
        for(int i = 1; i< weight + 1; i++)
        {
            if(weight ==1)
            {
                moveCharacterAction.jumpHight = 8;
                break;
            }
            if(weight ==2)
            {
                moveCharacterAction.jumpHight = 7;
                break;
            }
            if(weight ==3)
            {
                moveCharacterAction.jumpHight = 5;
                break;
            }
            if(weight ==4)
            {
                moveCharacterAction.jumpHight = 4;
                break;
            }
            
        }

        return moveCharacterAction.jumpHight;
    }
}
