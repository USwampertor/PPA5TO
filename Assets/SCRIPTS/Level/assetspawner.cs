using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assetspawner : MonoBehaviour {
    public Transform aspawner;
    public GameObject a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18;
    public GameObject r1, r2, r3, r4, r5, r6, r7, r8;
    public float timetospawn = 0;
    float rand, spawn;
    int conversion;
	// Use this for initialization
	void Start () {
        spawn = Random.Range(0f, 1f);
        timetospawn = spawn;
    }
	
	// Update is called once per frame
	void Update () {
        timetospawn -= Time.deltaTime;
        if (timetospawn < 0.1f)
        {
            rand = Random.Range(0f, 19f);
            int a = (int)rand;
            switch(a)
            {
                case 1:
                    Instantiate(a1, aspawner.position, aspawner.rotation);
                    break;
                case 2:
                    Instantiate(a2, aspawner.position, aspawner.rotation);

                    break;
                case 3:
                    Instantiate(a3, aspawner.position, aspawner.rotation);

                    break;
                case 4:
                    Instantiate(a4, aspawner.position, aspawner.rotation);

                    break;
                case 5:
                    Instantiate(a5, aspawner.position, aspawner.rotation);

                    break;
                case 6:
                    Instantiate(a6, aspawner.position, aspawner.rotation);

                    break;
                case 7:
                    Instantiate(a7, aspawner.position, aspawner.rotation);

                    break;
                case 8:
                    Instantiate(a8, aspawner.position, aspawner.rotation);

                    break;
                case 9:
                    Instantiate(a9, aspawner.position, aspawner.rotation);

                    break;
                case 10:
                    Instantiate(a10, aspawner.position, aspawner.rotation);

                    break;
                case 11:
                    Instantiate(a11, aspawner.position, aspawner.rotation);

                    break;
                case 12:
                    Instantiate(a12, aspawner.position, aspawner.rotation);

                    break;
                case 13:
                    Instantiate(a13, aspawner.position, aspawner.rotation);

                    break;
                case 14:
                    Instantiate(a14, aspawner.position, aspawner.rotation);

                    break;
                case 15:
                    Instantiate(a15, aspawner.position, aspawner.rotation);

                    break;
                case 16:
                    Instantiate(a16, aspawner.position, aspawner.rotation);

                    break;
                case 17:
                    Instantiate(a17, aspawner.position, aspawner.rotation);

                    break;
                case 18:
                    Instantiate(a18, aspawner.position, aspawner.rotation);

                    break;
                default:
                    break;
            }
            timetospawn = Random.Range(0f, 2f);
        }

    }
}
