using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformspawner : MonoBehaviour {
    public Transform centralplat;
    public GameObject plat1, plat2, plat3,coin;
    public float timetospawnp = 0;
    float randp,randcoin;
    Vector3 v1 = new Vector3(0, 2, 0);
    Vector3 v3 = new Vector3(0, -2, 0);
    // Update is called once per frame
    void Start()
    {
        timetospawnp = Random.Range(0f, 2f);
    }
   
    void Update()
    {

        timetospawnp -= Time.deltaTime;
        
        if (timetospawnp < 0.1f)
        {
            randp = Random.Range(0f, 3f);
            int iRandPlatformer = (int)randp;
            randcoin= Random.Range(1f, 3f);
            int iRandCoin = (int)randcoin;
            switch (iRandPlatformer)
            {
                case 1:
                    Instantiate(plat1, centralplat.position + v1, centralplat.rotation);
                    //for (float coinSpawner = 0f; coinSpawner < iRandCoin; ++coinSpawner) 
                    //{
                        Instantiate(coin, centralplat.position + v1+new Vector3(0,2,0), centralplat.rotation);
                    //}
                    break;
                case 2:
                    Instantiate(plat2, centralplat.position, centralplat.rotation);
                    //for (float coinSpawner = 0f; coinSpawner < iRandCoin; ++coinSpawner) 
                    //{
                        Instantiate(coin, centralplat.position + new Vector3(0, 2, 0), centralplat.rotation);
                    //}
                    break;
                case 3:
                    Instantiate(plat3, centralplat.position + v3, centralplat.rotation);
                    //for (float coinSpawner = 0f; coinSpawner < iRandCoin; ++coinSpawner) 
                    //{
                        Instantiate(coin, centralplat.position + v3 + new Vector3(0, 2, 0), centralplat.rotation);
                    //}
                    break;
            }
            timetospawnp = Random.Range(1f, 2f);
        }
    }
}
