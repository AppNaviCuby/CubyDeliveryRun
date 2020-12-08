using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushLeftButton : MonoBehaviour
{
public GameObject Unitychan;
private Rigidbody2D rb2D;
private float moveSpeed = 10f; // スピード
private float inputX = -1f; // 左へいく

void Awake()
{
rb2D = Unitychan.AddComponent<Rigidbody2D>();
}

// ボタンが押された場合、今回呼び出される関数
public void oshita()
{
Debug.Log("左押したよ　ボタン側");
rb2D.AddForce(new Vector2(0, inputX * moveSpeed));
}
}

