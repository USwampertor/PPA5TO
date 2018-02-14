using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treedestroyer : MonoBehaviour {

    public float floorlife = 0f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(5 * (Time.deltaTime), 0, 0);
        if (floorlife < 10)
        {
            floorlife += Time.deltaTime;
            if (floorlife >= 2f)
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
