using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshPro textoNiveles;
    [SerializeField] GeneradorMapa generadorMapa;
    [SerializeField] Canvas canvasVictoria;
    
    void Start()
    {
        ActualizarTextoNiv();
        canvasVictoria.enabled = false;
    }

    
    void Update()
    {
        
    }

    public void ActualizarTextoNiv()
    {
        if (generadorMapa.ModoInfinito == false)
        {
            textoNiveles.text = "LEVELS: " + generadorMapa.NumNiveles; 
        }
        else if (generadorMapa.ModoInfinito == true)
        {
            textoNiveles.text = "LEVELS: INF";
        }
    }

    public void MostrarCanvasVictoria()
    {
        canvasVictoria.enabled = true;
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene(0);
    }
}
