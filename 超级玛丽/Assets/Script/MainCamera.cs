using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Transform target;
    public float min, max;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = transform.position;
        v.x = target.position.x;
        if(v.x<min)
        {
            v.x = min;
        }
        if(v.x>max)
        {
            v.x = max;
        }

        transform.position = v;
	}
}