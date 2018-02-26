using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSpot : MonoBehaviour {

    float speed = 12;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().velocity = new Vector2(1, 0) * speed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag =="Player")
        {
            Destroy(other.gameObject);
        }
    }

}
