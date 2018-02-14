using UnityEngine;
using System.Collections;

public class Fly_Mode : MonoBehaviour {
    public Vector3 speed;
    public Rigidbody rb;
    public Vector3 upperLimits, bottomLimits, position;
    public Camera c;
	// Use this for initialization
	void Start () {
        speed = new Vector3(0, 20, 0);
        rb = GetComponent<Rigidbody>();
        c = Camera.main;
        bottomLimits = c.ScreenToWorldPoint(new Vector3(0, Screen.height / 8, 0));
        upperLimits = c.ScreenToWorldPoint(new Vector3(0, 7 * Screen.height / 8, 0));
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.position.y >= bottomLimits.y && rb.position.y <= upperLimits.y)
        {
            flying();
        }
        else
        {
            position = rb.position;
            if (rb.position.y > upperLimits.y)
            {
                position.y = upperLimits.y;
                rb.position = position;
            }
            if (rb.position.y < bottomLimits.y)
            {
                position.y = bottomLimits.y;
                rb.position = position;
            }
        }
	}

    void flying()
    {
        rb.velocity = Input.GetAxis("Vertical") * speed;
    }
}