using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assetdestroyer : MonoBehaviour {
    public float assetlife = 0f;
    public float speed;
    // Use this for initialization
    // Update is called once per frame
    private void Start()
    {
        //GetComponent<Rigidbody>().velocity = new Vector2(1,0) * speed;
    }
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
