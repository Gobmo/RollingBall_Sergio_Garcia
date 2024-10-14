using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    Rigidbody rb;
    float cooldownNitro = 3;
    public bool nitroReady = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded() == true)
        {
            Saltar();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && nitroReady)
        {
            Nitro();
        }
        if (nitroReady == false)
        {
            cooldownNitro -= Time.deltaTime;
            if (cooldownNitro <= 0)
            {
                nitroReady = true;
                cooldownNitro = 3;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, 2, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -2, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-2, 0, 0, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(2, 0, 0, ForceMode.Force);
        }
    }

    void Saltar()
    {
        rb.AddForce(0,5,0,ForceMode.Impulse);
    }

    void Nitro()
    {
        rb.AddForce(0, 0, 5, ForceMode.Impulse);
        nitroReady = false;
    }

    bool Grounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.65f);
    }
}
