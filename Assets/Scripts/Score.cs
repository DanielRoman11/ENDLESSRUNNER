using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int organico;
    private int aprovechable;
    private int postobon;
    public Text organicoTxt;
    public Text aprovechableTxt;
    public Text postobonTxt;
    // Start is called before the first frame update
    void Start()
    {
        organico = 0;
        aprovechable = 0;
        postobon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Organico")
        {
            organico++;
            organicoTxt.text = "Residuos Orgánicos: " + organico;
        }
        if (coll.gameObject.tag == "Aprovechable")
        {
            aprovechable++;
            aprovechableTxt.text = "Residuos Aprovechables: " + aprovechable;
        }
        if (coll.gameObject.tag == "Postobon")
        {
            postobon++;
            postobonTxt.text = "Botellas recolectadas: "+ postobon;
        }
    }
}
