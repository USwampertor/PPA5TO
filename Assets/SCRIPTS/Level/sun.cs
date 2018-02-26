using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour {
    public Light SunLight;
    public float duration = 20.0f;
    bool IsNight = false;
    // Use this for initialization
    void Start () {
        SunLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (IsNight==false)
            SunLight.intensity -= Time.deltaTime/duration;
        if(IsNight==true)
            SunLight.intensity += Time.deltaTime/ duration;
        if (SunLight.intensity <= 0)
            IsNight = true;
        if (SunLight.intensity >= 1)
            IsNight = false;
    }
}
