using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platstarter : MonoBehaviour {

    public float platlife = 0f;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (platlife < 5)
        {
            platlife += Time.deltaTime;
            if (platlife >= 2f)
            {
                Destroy(this.gameObject);
            }
        }
        if (platlife >= 2f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        Movement player = new Movement();
        if (col.gameObject.tag == "Player")
        {
            player.isGrounded = false;
        }
    }
}
