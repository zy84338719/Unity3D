using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour {
	public int Hp = 1;
	public float speed;
	private Animator ani;
	private Rigidbody2D rBody;
	
	private bool isGround;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator>();
		rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");
		if (horizontal!=0){
			// 移动速度
			transform.Translate(transform.right * speed* Time.deltaTime * horizontal);
			// 翻转
			if(horizontal> 0){
				GetComponent<SpriteRenderer>().flipX = false;
			}
			else if(horizontal<0){
				GetComponent<SpriteRenderer>().flipX = true;
			}
			// 播放动画
			ani.SetBool("run_Bool",true);
		}
		else{
			ani.SetBool("run_Bool",false);
		}

		
		
		if (Input.GetKeyDown(KeyCode.W) && isGround == true){
			rBody.AddForce(Vector2.up * 220f);
			AudioManager.Instance.PlaySound("跳");
		}

		if (v != 0){
        	transform.Translate(transform.up * speed* 0.75f * Time.deltaTime * v);
            ani.SetBool("jump_Bool", true);
		}
		else
        {
            ani.SetBool("jump_Bool", false);
			
        }

	}

	private void OnCollisionEnter2D(Collision2D Collision){
		if(Collision.collider.tag == "Ground"||Collision.collider.tag =="Pip"||Collision.collider.tag =="rock"){
			isGround = true;
			// ani.SetBool("jump_Bool",false);
		}
		
		if (Collision.collider.tag == "Enemy"){
			if (Collision.collider.GetComponent<EnemyControl>().Hp<0){
				return;
			}
			Hp--;
			if(Hp==1){
				AudioManager.Instance.PlaySound("顶出蘑菇,花或星");
				ani.SetBool("big",false);
			}
			if (Hp==0){
				ani.SetBool("die_Bool",true);
				GetComponent<Collider2D>().enabled = false;
				AudioManager.Instance.StopMusic();
				AudioManager.Instance.PlaySound("死亡1");
				Invoke("die",0.8f);
				//向上跳跃
				rBody.velocity = Vector2.zero;
				rBody.AddForce(Vector2.up*250f);
			}
		}
		if (Collision.collider.tag == "die"){
			ani.SetBool("die_Bool",true);
			GetComponent<Collider2D>().enabled = false;
			AudioManager.Instance.StopMusic();
			AudioManager.Instance.PlaySound("死亡1");
			Invoke("die",0.8f);
			//向上跳跃
			rBody.velocity = Vector2.zero;
			rBody.AddForce(Vector2.up*250f);
			Destroy(rBody, 1.0f);
		}
		
		
	}
	void die(){
		AudioManager.Instance.PlaySound("死亡2");
		Invoke("over",2f);
		
	}
	void over(){
		SceneManager.LoadScene("GameOver");
	}

	private void OnCollisionExit2D(Collision2D Collision){
		if (Collision.collider.tag == "Ground"||Collision.collider.tag =="Pip"||Collision.collider.tag =="rock"){
			isGround = false;
			// ani.SetBool("jump_Bool",true);
		}

	}
	void big2b(){
		ani.SetBool("big2",true);
	}
	private void OnTriggerEnter2D(Collider2D Collision){
		if (Collision.gameObject.tag == "fire"){
			ani.SetBool("big",true);
			Invoke("big2b",2f);
			AudioManager.Instance.PlaySound("顶出蘑菇,花或星");
			rBody.AddForce(Vector2.up*50f);
		}
	}


}
