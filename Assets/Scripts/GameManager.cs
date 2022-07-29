using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Renderer fondo;
    public GameObject Jugador;
    public Camera CamaraDeJuego;
    public GameObject[] BloquePreFab;
    public float PunteroJuego;
    public float SafetySpawn = 20;
    public Text TextoDeJuego;
    public bool Perdiste;

    // Start is called before the first frame update
    void Start()
    {
        PunteroJuego = 0;
        Perdiste = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Jugador != null)
        {
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.025f, 0) * Time.deltaTime;
            CamaraDeJuego.transform.position = new Vector3(
            Jugador.transform.position.x,
            CamaraDeJuego.transform.position.y,
            CamaraDeJuego.transform.position.z
            );
            TextoDeJuego.text = "Puntaje: " + Mathf.Floor(Jugador.transform.position.x);
        }
        else
        {
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0, 0) * Time.deltaTime;
            if (!Perdiste)
            {
                Perdiste = true;
                TextoDeJuego.text += "\n \nGame Over! \nPresione ENTER para empezar de nuevo";
            }
            if (Perdiste)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
        while(Jugador != null && PunteroJuego < Jugador.transform.position.x + SafetySpawn)
        {
            int indiceBloque = Random.Range(0, BloquePreFab.Length - 1);
            if (PunteroJuego <= 0)
            {
                indiceBloque = 0;
            }
            GameObject ObjetoBloque = Instantiate(BloquePreFab[indiceBloque]);
            ObjetoBloque.transform.SetParent(this.transform);
            Bloque bloque = ObjetoBloque.GetComponent<Bloque>();
            ObjetoBloque.transform.position = new Vector2(
                PunteroJuego + bloque.tamaño / 2,
                0
                );
            PunteroJuego += bloque.tamaño;
        }
    }
}
