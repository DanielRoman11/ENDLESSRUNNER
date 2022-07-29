using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void BotonStart()
    {
        SceneManager.LoadScene("VideoJuego");
    }

    public void BotonQuit()
    {
        Debug.Log("Quitamos la aplicación");
        Application.Quit();
    }
}
