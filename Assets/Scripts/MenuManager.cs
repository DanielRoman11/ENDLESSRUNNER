using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static bool Pausar;

    public GameObject MenuPausa;
    public GameObject MenuStats;

    private void Start()
    {
        MenuPausa.SetActive(false);
        MenuStats.SetActive(true);
    }
    public void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
        if (sceneName == "VideoJuego" && Input.GetKeyDown(KeyCode.Escape)){
            AlternarPause();
            
        }
    }
    public void BotonStart()
    {
        SceneManager.LoadScene("VideoJuego");
    }

    
    public void BotonQuit()
    {
        Debug.Log("Quitamos la aplicación");
        Application.Quit();
    }

    public void BotonMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void AlternarPause()
    {
        if (Pausar)
        {
            ReanudarBtn();
        }
        else
        {
            SalirBtn();
        }
    }
    void ReanudarBtn()
    {
        MenuStats.SetActive(true);
        MenuPausa.SetActive(false);
        Time.timeScale = 1;
        Pausar = false;
    }
    void SalirBtn()
    {
        MenuStats.SetActive(false);
        MenuPausa.SetActive(true);
        Time.timeScale = 0;
        Pausar = true;
    }

    public void mPrincipal(string name)
    {
        SceneManager.LoadScene(name);
    }
}