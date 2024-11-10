using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helices : MonoBehaviour
{
    float velocidad = 0f;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = Random.Range(9f, 14f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,15 * velocidad * Time.deltaTime, 0);
    }
}
