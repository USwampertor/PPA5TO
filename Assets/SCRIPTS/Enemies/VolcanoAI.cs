using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolcanoAI : MonoBehaviour {

    public GameObject  hazard, lavaDummy;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    //bool nextrock;
    int nextRock = 0;
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        
        //if (Scene.name == "escenariodia")
        //{
            yield return new WaitForSeconds(startWait);

        while (true)
        {
            //Debug.Log(nextRock);

            //Primer proyectil atras
            if (nextRock == 0)
            {
                Debug.Log("Soy roca dummy");
                Vector3 spawnPosition = new Vector3(7.19f, -2.99f, 9.94f);
                Instantiate(lavaDummy, spawnPosition, lavaDummy.transform.rotation);
                nextRock++;
            }
            else if (nextRock == 1)
            {
                Debug.Log("Soy roca shida");
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                nextRock--;
            }
                



            yield return new WaitForSeconds(spawnWait);
            yield return new WaitForSeconds(waveWait);
        }

        //}
        
    }
}	

