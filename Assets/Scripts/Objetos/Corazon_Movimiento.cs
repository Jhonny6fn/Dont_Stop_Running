using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon_Movimiento : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(0f, 1 * speed * Time.deltaTime, 0f);
        transform.eulerAngles = new Vector3(-90, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (other.tag == "ParedFinal")
        {
            Destroy(gameObject);
        }
    }
}