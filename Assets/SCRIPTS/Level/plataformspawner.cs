using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformspawner : MonoBehaviour {
    public Transform centralplat;
    public GameObject plat1, plat2, plat3,coin;
    public float timetospawnp = 0;
    float randp,randcoin;
    private Vector3 v;
    private GameObject plat;
    public Vector3 v1 = new Vector3(0, 2, 0);
    public Vector3 v2 = new Vector3(0, 0, 0);
    public Vector3 v3 = new Vector3(0, -2, 0);
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
            CreatePlataform();
            timetospawnp = Random.Range(1f, 2f);
        }
    }
    void CreatePlataform()
    {
        
        int iRandVector = (int)Random.Range(1f, 4f);
        int iRandTexture = (int)Random.Range(1f, 4f);
        switch (iRandVector)
        {
            case 1:
                v = v1;
                break;
            case 2:
                v = v2;
                break;
            case 3:
                v = v3;
                break;  
        }
        switch(iRandTexture)
        {
            case 1:
                plat = plat1;
                break;
            case 2:
                plat = plat2;
                break;
            case 3:
                plat = plat3;
                break;
        }
        //Debug.Log("Genere una plataforma"+ iRandVector);
        Instantiate(plat, centralplat.position+v, centralplat.rotation);
        Instantiate(coin, centralplat.position+v + new Vector3(0, 2, 0), centralplat.rotation);
    }
}
