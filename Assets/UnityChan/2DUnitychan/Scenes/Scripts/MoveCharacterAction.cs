using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterAction : MonoBehaviour
{
	static int hashSpeed = Animator.StringToHash ("Speed");
	static int hashFallSpeed = Animator.StringToHash ("FallSpeed");
	static int hashGroundDistance = Animator.StringToHash ("GroundDistance");
	static int hashIsCrouch = Animator.StringToHash ("IsCrouch");
    
	static int Max_jumpCount=2;
	static int jumpCount=0;
	static int hashDamage = Animator.StringToHash ("Damage");

	[SerializeField] private float characterHeightOffset = 0.2f;
	[SerializeField] LayerMask groundMask;

	[SerializeField, HideInInspector] Animator animator;
	[SerializeField, HideInInspector]SpriteRenderer spriteRenderer;
	[SerializeField, HideInInspector]Rigidbody2D rig2d;

	public int hp = 4;

	void Awake ()
	{
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rig2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		float axis = Input.GetAxis ("Horizontal");
		bool isDown = Input.GetAxisRaw ("Vertical") < 0;

        Vector2 velocity = rig2d.velocity;
		if (jumpCount< Max_jumpCount&&Input.GetButtonDown ("Jump")) {
			velocity.y = 5;
			jumpCount++;
		}
		if (axis != 0){
			spriteRenderer.flipX = axis < 0;
            velocity.x = axis * 2;
        }
        rig2d.velocity = velocity;


		var distanceFromGround = Physics2D.Raycast (transform.position, Vector3.down, 1, groundMask);

		// update animator parameters
		animator.SetBool (hashIsCrouch, isDown);
		animator.SetFloat (hashGroundDistance, distanceFromGround.distance == 0 ? 99 : distanceFromGround.distance - characterHeightOffset);
		animator.SetFloat (hashFallSpeed, rig2d.velocity.y);
		animator.SetFloat (hashSpeed, Mathf.Abs (axis));

	}
    

    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetTrigger(hashDamage);  
    }
	// private void OnCollisionEnter2D( Collision2D collision )
	// {
	// 	if (collision.gameObject.name == "Tilemap")
	// 	{
	// 		jumpCount = 0;
	// 	}
	// }
	void OnCollisionEnter2D(Collision2D other)
    {
        //自分があるオブジェクトと接触しているポイントを一つづつ調べる
        foreach (var contact in other.contacts) 
        {
            //自分から接触ポイントへのベクトル
            Vector2 dir = contact.point - (Vector2)transform.position;

            //接触しているゲームオブジェクトの下向きのベクトル
            Vector2 contactObjectDown = -contact.collider.gameObject.transform.up;

            //接触しているオブジェクトの下向きのベクトルと自身から接触しているポイントへのベクトルの
            //角度が１０度未満であった場合にジャンプの段階数のリセットする
            if (Vector2.Angle (contactObjectDown, dir) < 10.0f)
                jumpCount = 0;

            break;
        }
    }
}
