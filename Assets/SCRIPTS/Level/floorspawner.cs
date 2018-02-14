using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorspawner : MonoBehaviour {
    public Transform floorpos;
    public GameObject floor,floor2,floor3;
    public float timetospawn=0;
    public float spawn;
    float rand;
    // Update is called once per frame
    void Start()
    {
        timetospawn = spawn;
    }
    
	void Update ()
    {

        timetospawn -= Time.deltaTime;
        if (timetospawn < 0.1f)
        {
           rand = Random.Range(0f, 3f);
            if (rand <= 1f)
            {
                Instantiate(floor, floorpos.position, floorpos.rotation);
            }
            if (rand > 1f && rand <= 2f)
            {
                Instantiate(floor2, floorpos.position, floorpos.rotation);
            }
            if (rand > 2f && rand <= 3f)
            {
                Instantiate(floor3, floorpos.position, floorpos.rotation);
            }
            timetospawn = spawn;
        }
	}
}
