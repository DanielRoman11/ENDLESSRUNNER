using System.Collections;
using System.Collections.Generic;
using static MenuManager;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //Variable para saltar:
    public int FuerzaSalto;
    public float VelocidadMov;
    public int FuerzaCaida;
    public float vel;
    public bool Enpiso;
    public Transform refPie;

    //Variables de animaci�n de salto y rigidbody;
    Rigidbody2D rb;
    Animator anim;

    //Variables de aumento de Tiempo:
    float TiempoActual;
    public float AumentoSeg;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        TiempoActual = AumentoSeg * 60;
    }
    // Update is called once per frame
    void Update()
    {
        ProcesarSalto();
        AumentarSegundos();
    }
    void AumentarSegundos()
    {
        if(!Pausar){
            TiempoActual -= 1f;
            if (TiempoActual < 0)
            {
                VelocidadMov += vel;
                TiempoActual = AumentoSeg * 60;
            }
        }
    }
    void ProcesarSalto()
    {
        Enpiso = Physics2D.OverlapCircle(refPie.position,1f,1<<3);
        if(Pausar)
        {
            FuerzaSalto = 0;
        }
        else if (Pausar == false){
            bool isJumping = false;
            FuerzaSalto = 10;
            if (Input.GetKeyDown(KeyCode.UpArrow) && Enpiso && !isJumping)
            {
                rb.AddForce(new Vector2(0, FuerzaSalto), ForceMode2D.Impulse);
                if(FuerzaSalto > 0){
                    FuerzaSalto = 0;
                    isJumping = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.AddForce(new Vector2(0,FuerzaCaida), ForceMode2D.Impulse);
            }
            if(!Enpiso){
                FuerzaSalto = 0;
            }
        }
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(VelocidadMov, this.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Obstaculo") 
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enpiso = false;
    }
}