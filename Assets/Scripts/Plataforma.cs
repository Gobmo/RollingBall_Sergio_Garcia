using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    float contador = 1;
    int estado = 0;
    Vector3 direccion = new Vector3(0,0,0);
    [SerializeField] Vector3 posicionInicial, posicionFinal;
    [SerializeField] int velocidad;
    // Start is called before the first frame update
    void Start()
    {
        direccion = posicionFinal - posicionInicial;
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == 0)
        {
            contador -= Time.deltaTime;
            if (contador <= 0)
            {
                estado++;
                contador = 1;
            }
        }
        else if (estado == 1)
        {
            transform.Translate(direccion * velocidad * Time.deltaTime);
            if (transform.position.z >= posicionFinal.z)
            {
                estado++;
            }
        }
        else if (estado == 2)
        {
            contador -= Time.deltaTime;
            if (contador <= 0)
            {
                estado++;
                contador = 1;
            }
        }
        else if (estado  == 3)
        {
            transform.Translate(-direccion * velocidad * Time.deltaTime);
            if (transform.position.z <= posicionInicial.z)
            {
                estado = 0;
            }
        }
        
    }
}
