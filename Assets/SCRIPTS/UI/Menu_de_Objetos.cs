using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu_de_Objetos : MonoBehaviour {

    public GameObject Menu_Incial;
    public GameObject Menu_Niveles;
    public GameObject Menu_Opciones;
    public GameObject Menu_Tienda;
    public GameObject Izquierda;
    public GameObject Derecho;
    public GameObject Centro;
    public GameObject Cuerpo;
    public Image[] cabezas;

    public void Opciones()
    {
        Menu_Incial.SetActive(false);
        Menu_Niveles.SetActive(false);
        Menu_Tienda.SetActive(false);
        Menu_Opciones.SetActive(true);
    }

    public void Niveles()
    {
        Menu_Incial.SetActive(false);
        Menu_Opciones.SetActive(false);
        Menu_Tienda.SetActive(false);
        Menu_Niveles.SetActive(true);
    }

    public void Inicial()
    {
        Menu_Niveles.SetActive(false);
        Menu_Opciones.SetActive(false);
        Menu_Tienda.SetActive(false);
        Menu_Incial.SetActive(true);
    }

    public void Tienda()
    {
        Menu_Niveles.SetActive(false);
        Menu_Opciones.SetActive(false);
        Menu_Tienda.SetActive(true);
        Menu_Incial.SetActive(false);
    }

    public void Gorrito_izq()
    {
        Derecho.GetComponent<AudioSource>().Pause();
    }

    public void Gorrito_Der()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }


    public void Jugar(string NombreEscena)
    {
        SceneManager.LoadScene(NombreEscena);
    }

    void Start()
    {
        Menu_Incial = GameObject.Find("Menu-1");
        Menu_Niveles = GameObject.Find("Menu-2");
        Menu_Opciones = GameObject.Find("Menu-3");
        Menu_Tienda = GameObject.Find("Menu-4");

        Menu_Niveles.SetActive(false);
        Menu_Opciones.SetActive(false);
        Menu_Tienda.SetActive(false);
    }


    void Update()
    {


    }

}

