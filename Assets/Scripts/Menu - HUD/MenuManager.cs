using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }

    public void Medio()
    {
        SceneManager.LoadScene("Medium");
    }

    public void Hard()
    {
        SceneManager.LoadScene("Hard");
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
}
