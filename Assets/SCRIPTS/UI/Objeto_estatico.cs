using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Objeto_estatico : MonoBehaviour {

    public GameObject Inmortal;
    public Slider Volumen;

    public 

    void Awake()
    {
        DontDestroyOnLoad(Inmortal);
    }

    public void Terminar()
    {
        Inmortal.GetComponent<AudioSource>().Pause();
        Inmortal.GetComponent<AudioSource>().Stop();
    }

    public void Reiniciar()
    {
        Inmortal.GetComponent<AudioSource>().Play();
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        Inmortal.GetComponent<AudioSource>().volume = Volumen.value;
    }
}
