using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
	public int Hp = 1;
	private int dir  = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Hp <= 0){
			return;
		}
		transform.Translate(transform.right * dir * 0.5f*Time.deltaTime);
	}
	private void OnCollisionEnter2D(Collision2D Collision){
		dir = -dir; 
	}

	private void OnTriggerEnter2D(Collider2D Collision){
		if(Collision.tag == "Player"){
			Hp--;
			if(Hp<= 0 ){
				Destroy(gameObject, 0.5f);
				Collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 70f);
				AudioManager.Instance.PlaySound("踩敌人");
				GetComponent<Animator>().SetBool("die_Bool", true);
				
			}
		}
	}
}
