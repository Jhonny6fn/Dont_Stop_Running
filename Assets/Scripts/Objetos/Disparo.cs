using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject Player;
    public Transform torre;

    public GameObject Bola;
    public Transform PuntoDisparo;

    public float velocidadDisparo = 10f;
    public float tiempoDeDisparo = 1.5f;
    float tiempoOriginal;


    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        tiempoOriginal = tiempoDeDisparo;
    }

    void Update()
    {
        torre.LookAt(Player.transform);
    }

    private void FixedUpdate()
    {
        tiempoDeDisparo -= Time.deltaTime;
        if (tiempoDeDisparo < 0)
        {
            DisparoBola();
            tiempoDeDisparo = tiempoOriginal;
        }
    }

    private void DisparoBola()
    {
        GameObject currentBullet = Instantiate(Bola, PuntoDisparo.position, PuntoDisparo.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
        rig.AddForce(transform.forward * velocidadDisparo, ForceMode.VelocityChange);
    }
}