using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRock : MonoBehaviour {

    // Use this for initialization
    public float tumble;
    public GameObject lavaSpot;
    public Texture lava;
    float speed=6;
    public bool nextRock=false;
    void Start()
    {
        if (gameObject.tag == "LavaRock")
        {
            LavaDrop();
        }
        else if (gameObject.tag == "LavaDummy")
        {
            LavaThrow();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        
    }

    void LavaDrop()
    {
        GetComponent<Rigidbody>().velocity = new Vector2(0, -1) * speed;
    }

    void LavaThrow()
    {
        GetComponent<Rigidbody>().velocity = new Vector2(0, 1) * speed;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
          
            Vector3 spawnPosition = new Vector3(transform.position.x, -5.5f, 0.5f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(lavaSpot, spawnPosition, spawnRotation);
        }
        else if (other.gameObject.tag == "Platform")
        {
            Destroy(gameObject);

            Vector3 spawnPosition = new Vector3(other.transform.position.x, (other.transform.position.y+1.2f), other.transform.position.z/2);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(lavaSpot, spawnPosition, spawnRotation);
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "boundary")
        {
            
            if (gameObject.tag == "LavaDummy")
            {                
                Destroy(gameObject);
            }
                
        }

        
        //Destroy(other.gameObject);
        //Destroy(gameObject);
    }
}
