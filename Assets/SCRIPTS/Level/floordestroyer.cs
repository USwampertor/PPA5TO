using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floordestroyer : MonoBehaviour {
    public float floorlife =0f;
	// Update is called once per frame
	void Update () {
        transform.Translate(12*(Time.deltaTime),0, 0);
        if (floorlife<5)
        {
            floorlife += Time.deltaTime;
            if(floorlife>=2f)
            {
                Destroy(this.gameObject);
            }
        }
        if (floorlife >= 2f)
        {
            Destroy(this.gameObject);
        }
    }
}
