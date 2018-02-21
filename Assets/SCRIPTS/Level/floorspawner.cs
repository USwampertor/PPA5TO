using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorspawner : MonoBehaviour {
    public Transform floorpos;
    public GameObject floor,floor2,floor3;
    public float timetospawn=0;
    public float spawn;
    float rand;
    public int holeaccumulator = 0,rand2=0,holeemptier=0;
    public bool hole = false;
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
           if(hole!=true)
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
                rand2 = (int)Random.Range(0f, 10f);
                if (rand2%2 == 1)
                {
                    ++holeaccumulator;
                }
            }
           else
            {

                holeemptier--;
                if(holeemptier<=0)
                {
                    hole = false;
                }
            }
        }
        if (holeaccumulator >= 15)
        {
            hole = true;
            holeemptier = holeaccumulator;
            holeaccumulator = 0;
            rand2 = (int)Random.Range(0f, 10f);
            if(rand2%3==1)
            {
                holeemptier *= 2;
            }
            if(rand2%3==2)
            {
                holeemptier *= 3;
            }
        }
	}
}
