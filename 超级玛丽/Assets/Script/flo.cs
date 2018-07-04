using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flo : MonoBehaviour {
	public float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time +=Time.deltaTime;
		if (time > 2){
			if(time < 3){
				transform.Translate(transform.up*-1f*Time.deltaTime);
			}
			else if(time<4)
			{
				transform.Translate(transform.up*1f*Time.deltaTime);
			}
			else{
				Vector3 v=transform.position;
				v.y=-0.152f;
				transform.position = v;
				time -=4;
			}
		}
	}
}
