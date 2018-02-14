using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treespawner : MonoBehaviour {
    public Transform tspawner;
    public GameObject tree, tree2, tree3,tree4,tree5,tree6,tree7,tree8;
    public float timetospawn = 0;
    float spawn;
    float rand;
    int conversion;
    // Update is called once per frame
    void Start()
    {
        spawn = Random.Range(0f, 1f);
        timetospawn = spawn;
    }

    void Update()
    {

        timetospawn -= Time.deltaTime;
        if (timetospawn < 0.1f)
        {
            rand = Random.Range(0f, 9f);
            int c = (int)rand;
            if (c==1)
            {
                Instantiate(tree, tspawner.position, tspawner.rotation);
            }
            if (c==2)
            {
                Instantiate(tree2, tspawner.position, tspawner.rotation);
            }
            if (c==3)
            {
                Instantiate(tree3, tspawner.position, tspawner.rotation);
            }
            if (c == 4)
            {
                Instantiate(tree4, tspawner.position, tspawner.rotation);
            }
            if (c == 5)
            {
                Instantiate(tree5, tspawner.position, tspawner.rotation);
            }
            if (c == 6)
            {
                Instantiate(tree6, tspawner.position, tspawner.rotation);
            }
            if (c == 7)
            {
                Instantiate(tree7, tspawner.position, tspawner.rotation);
            }
            if (c == 8)
            {
                Instantiate(tree8, tspawner.position, tspawner.rotation);
            }
            timetospawn = Random.Range(0f,2f);
        }
    }
}
