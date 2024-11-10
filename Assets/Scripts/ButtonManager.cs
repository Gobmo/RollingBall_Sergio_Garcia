using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] GameObject pulsador;
    private float yInicial = 0.17f, yFinal = 0.03f;
    [SerializeField] GeneradorMapa generadorMapa;
    GameObject genMapa, gameMan;
    [SerializeField] GameManager gameManager;

    void Start()
    {
        genMapa = GameObject.Find("GeneradorMapa");
        gameMan = GameObject.Find("GameManager");

        generadorMapa = genMapa.GetComponent<GeneradorMapa>();
        gameManager = gameMan.GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pulsador.transform.position = new Vector3(transform.position.x, yFinal, transform.position.z);
            if (id == 1) // Sumar plataformas hasta la meta
            {
                generadorMapa.NumNiveles += 1;
                Debug.Log(generadorMapa.NumNiveles);
            }
            else if (id == 2) // Restar plataformas hasta la meta
            {
                if (generadorMapa.NumNiveles > 1)
                {
                    generadorMapa.NumNiveles -= 1;
                }
                    
            }

            else if (id == 3) // Modo infinito
            {

                generadorMapa.ModoInfinito = !generadorMapa.ModoInfinito;
                    
                Debug.Log(generadorMapa.ModoInfinito);
            }
            else if (id == 5) // Empezar partida
            {
                generadorMapa.Activo = true;
            }
            gameManager.ActualizarTextoNiv();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pulsador.transform.position = new Vector3(transform.position.x, yInicial, transform.position.z);
        }
    }
}
