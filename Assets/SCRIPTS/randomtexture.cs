using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomtexture : MonoBehaviour {

    public Texture2D a, b, c;
    public int random;
    void Start ()
    {
        float rand = Random.Range(0f, 3f);
        if(rand<=1f)
        {
        }
        if (rand>1f&&rand <= 2f)
        {

        }
        if (rand > 2f && rand <= 3f)
        {

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
