using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D Collection){
		if(Collection.tag == "Player")
		{
			AudioManager.Instance.PlaySound("金币");
			Destroy(gameObject);
		}
	}
}
