using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pelota : MonoBehaviour
{
    Rigidbody rb;
    Renderer renderer;
    float cooldownNitro = 3, contador = 10f;
    bool victoria = false;
    [SerializeField] GeneradorMapa generadorMapa;
    [SerializeField] GameManager gameManager;
    public bool nitroReady = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
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
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
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

        if (victoria == true)
        {
            transform.position = new Vector3(0, 0.77f, -5);
            rb.velocity = Vector3.zero;
            gameManager.MostrarCanvasVictoria();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, 6, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -6, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-6, 0, 0, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(6, 0, 0, ForceMode.Force);
        }
    }

    void Saltar()
    {
        rb.AddForce(0,5,0,ForceMode.Impulse);
    }

    void Nitro()
    {
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
        nitroReady = false;
    }

    bool Grounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.65f);
    }

    void CambiarColor()
    {
        int aleatorio = Random.Range(0, 9);
        if (aleatorio == 0)
            renderer.material.color = Color.yellow;
        else if (aleatorio == 1)
            renderer.material.color = Color.magenta;
        else if (aleatorio == 2)
            renderer.material.color = Color.red;
        else if (aleatorio == 3)
            renderer.material.color = Color.white;
        else if (aleatorio == 4)
            renderer.material.color = Color.cyan;
        else if (aleatorio == 5)
            renderer.material.color = Color.blue;
        else if (aleatorio == 6)
            renderer.material.color = Color.black;
        else if (aleatorio == 7)
            renderer.material.color = Color.gray;
        else if (aleatorio == 8)
            renderer.material.color = Color.green;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EmpezarPartida")
        {
            rb.velocity = new Vector3(0,0,0);
            transform.position = new Vector3(0, 0.77f, -5);
        }

        if (other.gameObject.tag == "Reset")
        {
            if (generadorMapa.ModoInfinito == true)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                transform.position = new Vector3(0, 0.77f, -5);
            }
        }

        if (other.gameObject.tag == "BotonCambioColor")
        {
            CambiarColor();
        }

        if (other.gameObject.tag == "Final")
        {
            victoria = true;
        }
    }
}
