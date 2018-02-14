using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assetdestroyer : MonoBehaviour {
    public float assetlife = 0f;
	// Use this for initialization
	// Update is called once per frame
	void Update () {
        transform.Translate(15 * (Time.deltaTime), 0, 0);
        if(assetlife<5){
            assetlife += Time.deltaTime;
            if(assetlife>=2f)
            {
                Destroy(this.gameObject);
            }
        }
        if (assetlife >= 2f)
        {
            Destroy(this.gameObject);
        }
    }
}
