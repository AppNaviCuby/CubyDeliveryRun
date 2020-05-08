using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoalGate();
    }

    void GoalGate(){
            Transform myTransform = this.transform;
 
        // 先ほど取得したTransformの情報から座標の情報を取得
　　　　// Vector3：3D ベクトルと位置の表現
        Vector2 pos = myTransform.position;
 
        // x,y,z座標の値をフレームごと0.05加算する
        
        pos.y -= 0.05f;
    
 
        // 自分の座標を加算した値に設定
        myTransform.position = pos;
 
    }

}
