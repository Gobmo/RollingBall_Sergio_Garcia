using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    float contador = 1f;
    int estado = 0;
    float xMaxIzq = 0f, xMaxDer = 0f;
    float velocidad = 0f;
    // Start is called before the first frame update
    void Start()
    {
        xMaxIzq = Random.Range(-20f, -15f);
        xMaxDer = Random.Range(15f, 20f);
        estado = Random.Range(0, 4);
        velocidad = Random.Range(4f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == 0) // Se para
        {
            contador -= Time.deltaTime;
            if (contador <= 0)
            {
                estado++;
                contador = 1;
            }
        }
        else if (estado == 1) // Ir a la derecha
        {
            transform.Translate(transform.right * velocidad * Time.deltaTime);
            if (transform.position.x >= xMaxDer)
            {
                estado++;
            }
        }
        else if (estado == 2) // Se para
        {
            contador -= Time.deltaTime;
            if (contador <= 0)
            {
                estado++;
                contador = 1;
            }
        }
        else if (estado  == 3) // Ir a la izquierda
        {
            transform.Translate(-transform.right * velocidad * Time.deltaTime);
            if (transform.position.x <= xMaxIzq)
            {
                estado = 0;
            }
        }
        
    }
}
