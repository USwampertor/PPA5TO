using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floordestroyer : MonoBehaviour {
    public float floorlife =0f;
    public float speed;
    private Rigidbody RigidB;
	// Update is called once per frame
    void Start()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(1f,2f,3f);
    }
	void Update () {
        transform.Translate(12*(Time.deltaTime),0, 0);
        
        if (floorlife<5)
        {
            floorlife += Time.deltaTime;
            if(floorlife>=2f)
            {
                Destroy(this.gameObject);
            }
        }
        if (floorlife >= 2f)
        {
            Destroy(this.gameObject);
        }
    }
}
