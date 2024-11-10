using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMapa : MonoBehaviour
{
    private int numNiveles = 1;
    private bool modoInfinito = false;
    private int azar = 0;
    private bool activo = false;
    private int numNivelesGenerados = 0;
    [SerializeField] Transform player;
    [SerializeField] GameObject[] trozosMapa = new GameObject[3];
    [SerializeField] GameObject plataformaFinal;

    public int NumNiveles { get => numNiveles; set => numNiveles = value; }
    public bool ModoInfinito { get => modoInfinito; set => modoInfinito = value; }
    public bool Activo { get => activo; set => activo = value; }

    void Start()
    {
        activo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.z - player.transform.position.z) <= 8000 && activo == true)
        {
            GenerarPaneles();
        }
    }

    void GenerarPaneles()
    {
        if (ModoInfinito == false)
        {
            if (numNivelesGenerados < numNiveles && modoInfinito == false)
            {
                azar = Random.Range(0, 3);
                if (azar == 0)
                {
                    transform.position += new Vector3(0, -10.7f, 39.86958f);
                    Instantiate(trozosMapa[azar], transform.position, transform.rotation);
                    transform.position += new Vector3(5, -10.7347097f, 40.1284027f);
                }
                else
                {
                    transform.position += new Vector3(0, 0, 40);
                    Instantiate(trozosMapa[azar], transform.position, transform.rotation);
                    transform.position += new Vector3(0, 0, 40);
                }
                numNivelesGenerados++;
            }
            else
            {
                transform.position += new Vector3(0, 0, 5);
                Instantiate(plataformaFinal, transform.position, transform.rotation);
                activo = false;
            } 
        }
        else
        {
            azar = Random.Range(0, 3);
            if (azar == 0)
            {
                transform.position += new Vector3(0, -10.7f, 39.86958f);
                Instantiate(trozosMapa[azar], transform.position, transform.rotation);
                transform.position += new Vector3(5, -10.7347097f, 40.1284027f);
            }
            else
            {
                transform.position += new Vector3(0, 0, 40);
                Instantiate(trozosMapa[azar], transform.position, transform.rotation);
                transform.position += new Vector3(0, 0, 40);
            }
        }
    }
}
