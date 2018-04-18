using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
public class Menu_de_Objetos : MonoBehaviour
{
    public GameObject Menu_Incial;
    public GameObject Menu_Niveles;
    public GameObject Menu_Opciones;
    public GameObject Menu_Tienda;
    public GameObject Izquierda;
    public GameObject Derecho;
    public GameObject Centro;
    public GameObject Centro2;
    public GameObject Cuerpo;
    public Sprite[] cabezas;
    public Sprite fondo;
    int i1 = 1, i2 = 0, i3 = 2;
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
        i1++;
        i2++;
        i3++;
        if (i1 == 6)
        { i1 = 0; }
        if (i2 == 6)
        { i2 = 0; }
        if (i3 == 6)
        { i3 = 0; }
        Derecho.GetComponent<SpriteRenderer>().sprite = cabezas[i2];
        Centro.GetComponent<SpriteRenderer>().sprite = cabezas[i1];
        Centro2.GetComponent<SpriteRenderer>().sprite = cabezas[i1];
        Izquierda.GetComponent<SpriteRenderer>().sprite = cabezas[i3];
    }
    public void Gorrito_Der()
    {
        i1--;
        i2--;
        i3--;
        if (i1 == -1)
        { i1 = 6; }
        if (i2 == -1)
        { i2 = 6; }
        if (i3 == -1)
        { i3 = 6; }
        Derecho.GetComponent<SpriteRenderer>().sprite = cabezas[i2];
        Centro.GetComponent<SpriteRenderer>().sprite = cabezas[i1];
        Centro2.GetComponent<SpriteRenderer>().sprite = cabezas[i1];
        Izquierda.GetComponent<SpriteRenderer>().sprite = cabezas[i3];
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
        Derecho.GetComponent<SpriteRenderer>().sprite = cabezas[i2];
        Centro.GetComponent<SpriteRenderer>().sprite = cabezas[i1];
        Centro2.GetComponent<SpriteRenderer>().sprite = cabezas[i1];
        Izquierda.GetComponent<SpriteRenderer>().sprite = cabezas[i3];
        Cuerpo.GetComponent<SpriteRenderer>().sprite = fondo;
        Menu_Niveles.SetActive(false);
        Menu_Opciones.SetActive(false);
        Menu_Tienda.SetActive(false);
    }

    void Update()
    {

    }
}

