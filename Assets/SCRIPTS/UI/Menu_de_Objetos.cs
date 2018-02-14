using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu_de_Objetos : MonoBehaviour {

    public GameObject Menu_Incial;
    public GameObject Menu_Niveles;
    public GameObject Menu_Opciones;

    public void Opciones()
    {
        Menu_Incial.SetActive(false);
        Menu_Niveles.SetActive(false);
        Menu_Opciones.SetActive(true);
    }

    public void Niveles()
    {
        Menu_Incial.SetActive(false);
        Menu_Opciones.SetActive(false);
        Menu_Niveles.SetActive(true);
    }

    public void Inicial()
    {
        Menu_Niveles.SetActive(false);
        Menu_Opciones.SetActive(false);
        Menu_Incial.SetActive(true);
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

        Menu_Niveles.SetActive(false);
        Menu_Opciones.SetActive(false);
    }


    void Update()
    {


    }

}

