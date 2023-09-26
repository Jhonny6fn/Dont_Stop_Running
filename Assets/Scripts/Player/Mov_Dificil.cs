using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mov_Dificil : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    public float Vida;
    public Slider barraVida;
    public float VidaCorazon;
    public float danoBola;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                rb.velocity = new Vector3(-1 * speed, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                rb.velocity = new Vector3(1 * speed, 0, 0);
            }
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            if (this.gameObject.transform.position.z < LevelBoundary.frontSide)
            {
                rb.velocity = new Vector3(0, 0, 1 * speed);
            }
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            if (this.gameObject.transform.position.z < LevelBoundary.frontSide)
            {
                rb.velocity = new Vector3(0, 0, -1 * speed);
            }
        }

        barraVida.value = Vida;
        if (Vida <= 0)
        {
            SceneManager.LoadScene("Dificil");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ParedFinal")
        {
            SceneManager.LoadScene("Dificil");
            Destroy(gameObject);
        }

        if (other.tag == "Corazon")
        {
            if (Vida < 4.5f)
            {
                Vida += VidaCorazon;
            }
        }

        if (other.tag == "Bola")
        {
            Vida -= danoBola;
        }
    }
}