using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenuDerrota : MonoBehaviour
{
    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}