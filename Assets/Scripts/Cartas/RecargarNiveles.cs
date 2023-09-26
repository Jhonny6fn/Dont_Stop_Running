using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecargarNiveles : MonoBehaviour
{
    public void RecargarFacil()
    {
        SceneManager.LoadScene("Easy");
    }

    public void RecargarMedio()
    {
        SceneManager.LoadScene("Medium");
    }

    public void RecargarDificil()
    {
        SceneManager.LoadScene("Hard");
    }
}