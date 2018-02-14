using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class inicio : MonoBehaviour
{
   // public AudioSource intro;
    void Start()
    {
   //     intro.Play();
    }
    public void reintentar()
    {
        SceneManager.LoadScene("escenariodia");
    }
    public void creditos()
    {
        SceneManager.LoadScene("credits");
    }
    public void start()
    {
        SceneManager.LoadScene("Escena1");
    }
    public void salir()
    {
		Application.Quit ();
    }
    public void win()
    {
        SceneManager.LoadScene("win");
    }
}
