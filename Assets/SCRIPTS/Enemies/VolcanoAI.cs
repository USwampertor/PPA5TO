using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolcanoAI : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

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

                for (int i = 0; i < hazardCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);

                    yield return new WaitForSeconds(spawnWait);
                }


                yield return new WaitForSeconds(waveWait);

                //if (gameOver)
                //{
                //    restartText.text = "Press 'R' for Restart";
                //    restart = true;
                //    break;
                //}
        }

        //}
        
    }
}	

