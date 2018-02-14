using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour {
    public float rotateSpeed = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
    }
}
