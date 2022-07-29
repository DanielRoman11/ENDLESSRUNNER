using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFondo : MonoBehaviour
{
    public Renderer fondo;
    // Start is called before the first frame update
    void Start()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.035f, 0) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.035f, 0) * Time.deltaTime;
    }
}
