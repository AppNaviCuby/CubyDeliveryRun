using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmoriController : MonoBehaviour
{
    [SerializeField, HideInInspector] Animator unitychanAnimator;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float direction;
    Rigidbody2D omoriRb;
    MoveCharacterAction unitychanController;
    //public int omoriMass = 1;

    // Start is called before the first frame update
    void Start()
    {
        omoriRb = this.transform.parent.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 hajiLeft = new Vector2(transform.position.x - (0.47f * transform.lossyScale.x), transform.position.y);
        Vector2 hajiRight = new Vector2(transform.position.x + (0.47f * transform.lossyScale.x), transform.position.y);
        Vector2 centerX = new Vector2(transform.position.x, transform.position.y);

        Debug.DrawRay(hajiLeft, Vector2.down * 0.52f, Color.yellow);
        Debug.DrawRay(hajiRight, Vector2.down * 0.52f, Color.yellow);
        Debug.DrawRay(centerX, Vector2.down * 0.52f, Color.yellow);
        Debug.DrawRay(hajiLeft, Vector2.left * 0.05f, Color.red);
        Debug.DrawRay(hajiRight, Vector2.right * 0.05f, Color.red);

        if(/*Physics2D.Raycast (hajiLeft, Vector2.down, 0.55f, groundMask) && Physics2D.Raycast (hajiRight, Vector2.down, 0.55f, groundMask)||*/ Physics2D.Raycast (centerX, Vector2.down, 0.52f, groundMask))
        {
            //Debug.Log("地上");
            Vector2 groundVelocity = omoriRb.velocity;

            if(Physics2D.Raycast (hajiLeft, Vector2.left, 0.05f, groundMask) ||Physics2D.Raycast (hajiRight, Vector2.right, 0.05f, groundMask))
            {
                groundVelocity.x = 0f;
            }
            groundVelocity.y = 0f;
            omoriRb.velocity = groundVelocity;
        }else if(!Physics2D.Raycast (hajiLeft, Vector2.down, 0.52f, groundMask) && !Physics2D.Raycast (hajiRight, Vector2.down, 0.52f, groundMask))
        {
            //Debug.Log("地上じゃない");
            omoriRb.velocity = Vector2.down * 2;
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D thisCollision)
    {
        if(thisCollision.gameObject.tag == "Character")
        {
            //Debug.Log("キャラに触れた");
            //unitychanをobstacleが動いている間ストップさせる。その際、状態をidleに戻す　
            unitychanController = thisCollision.gameObject.GetComponent<MoveCharacterAction>();
            unitychanAnimator = thisCollision.gameObject.GetComponent<Animator>();
            unitychanAnimator.SetFloat ("Speed", 0f);
            unitychanController.enabled = false;
            omoriRb.velocity = Vector2.right * direction;
            yield return new WaitForSeconds(1.0f);
            unitychanController.enabled = true;
            omoriRb.velocity = Vector2.zero;
        }
    }
}