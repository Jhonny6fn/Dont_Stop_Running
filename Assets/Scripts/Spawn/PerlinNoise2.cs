using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise2 : MonoBehaviour
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

    public float ValorParedes1;
    public float ValorParedes2;
    public float ValorTorreta1;
    public float ValorTorreta2;
    public float ValorCorazon;

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

        for (int x = 1; x < width; x++)
        {
            valor = CalculateWall(x, 0);

            if ((valor > ValorParedes1) && (valor < ValorParedes2))
            {
                Vector3 pos = new Vector3(x, gameObject.transform.position.y, 0);
                GameObject clon = Instantiate(muro, pos, Quaternion.identity) as GameObject;
                clon.SetActive(true);
            }
            float posX = Random.Range(1, width);
            valor = Random.Range(0f, 100f);
            if ((valor > ValorTorreta1) && (valor < ValorTorreta2))
            {
                Vector3 Turretpos = new Vector3(posX, gameObject.transform.position.y, 0);
                GameObject Torretaclon = Instantiate(torreta, Turretpos, Quaternion.identity) as GameObject;
                Torretaclon.transform.parent = gameObject.transform;
                Torretaclon.SetActive(true);
            }
            else if (valor >= ValorCorazon)
            {
                Vector3 Bonuspos = new Vector3(posX, gameObject.transform.position.y, 0);
                GameObject Bonusclon = Instantiate(corazon, Bonuspos, Quaternion.identity) as GameObject;
                Bonusclon.transform.parent = gameObject.transform;
                Bonusclon.SetActive(true);
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