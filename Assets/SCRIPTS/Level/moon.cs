using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moon : MonoBehaviour {

    public Light MoonLight;
    public float duration = 40.0f;
    bool IsNight = true;
    // Use this for initialization
    void Start()
    {
        MoonLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsNight == true)
            MoonLight.intensity -= Time.deltaTime / duration;
        if (IsNight == false)
            MoonLight.intensity += Time.deltaTime / duration;
        if (MoonLight.intensity <= 0)
            IsNight = false;
        if (MoonLight.intensity >= 0.5f)
            IsNight = true;
    }
}
