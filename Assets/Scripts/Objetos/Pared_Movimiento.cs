using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared_Movimiento : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(0f, 0f, speed * Time.deltaTime * -1);
        Destroy(this.gameObject, 15f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ParedFinal")
        {
            Destroy(gameObject);
        }
    }
}