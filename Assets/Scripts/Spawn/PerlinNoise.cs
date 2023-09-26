using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public GameObject muro;
    public GameObject corazon;
    public GameObject torreta;

    public int width = 256;
    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetY = 100f;
    public float VariableY;
    public float Repeticiones;

    private void Start()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);
        InvokeRepeating("Spawner", 0f, Repeticiones);
    }

    void Spawner()
    {
        float valor;
        offsetY++;
        offsetX++;

        for (int x = 0; x < width; x++)
        {
            valor = CalculateWall(x, 0);

            if ((valor > 0.55) && (valor < 0.75))
            {
                Vector3 pos = new Vector3(x, gameObject.transform.position.y, 0);
                GameObject clon = Instantiate(muro, pos, Quaternion.identity) as GameObject;
                clon.SetActive(true);
            }
            float posX = Random.Range(0, 23);
            valor = Random.Range(0f, 100f);
            if ((valor > 0) && (valor < 5))
            {
                Vector3 Turretpos = new Vector3(posX, gameObject.transform.position.y, 0);
                GameObject Torretaclon = Instantiate(corazon, Turretpos, Quaternion.identity) as GameObject;
                Torretaclon.transform.parent = gameObject.transform;
                Torretaclon.SetActive(true);
            }
        }

        float CalculateWall(int x, int y)
        {
            float xCoord = ((float)x / width) * scale + offsetX;
            float yCoord = ((float)y / width) * scale + offsetY;

            float sample = Mathf.PerlinNoise(xCoord, yCoord);
            return sample;
        }
    }
}