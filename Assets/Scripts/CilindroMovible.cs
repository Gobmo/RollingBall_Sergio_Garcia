using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CilindroMovible : MonoBehaviour
{
    float velocidad = 0f;
    float xIzqMax = -4.8f, xDerMax = 4.8f;
    int estado = 0;

    void Start()
    {
        velocidad = Random.Range(4f, 8f);
        estado = Random.Range(0, 2);
    }

    void Update()
    {
        if (estado == 0) // Ir a la izquierda
        {
            transform.Translate(-transform.right * velocidad * Time.deltaTime);
        }
        else if (estado == 1) // Ir a la derecha
        {
            transform.Translate(transform.right * velocidad * Time.deltaTime);
        }
        if (transform.position.x < xIzqMax) // Pasar a ir a la derecha
        {
            estado = 1;
        }
        else if (transform.position.x > xDerMax) // Pasar a ir a la izquierda
        {
            estado = 0;
        }
    }
}
