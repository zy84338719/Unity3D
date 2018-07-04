using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D Collision){
		if(Collision.tag == "Player"){
			AudioManager.Instance.PlaySound("顶砖石块,壳击墙或火球撞墙");
			// GetComponent<Animator>().SetBool("r", true);
		}
	}
}
