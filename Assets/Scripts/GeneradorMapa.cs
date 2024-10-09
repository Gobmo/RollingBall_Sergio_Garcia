using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMapa : MonoBehaviour
{
    Vector3 posicionMover = Vector3.zero;
    [SerializeField] GameObject[] trozosMapa = new GameObject[9];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            posicionMover += new Vector3();
        }
    }
}
