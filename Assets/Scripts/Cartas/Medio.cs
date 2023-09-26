using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Medio : MonoBehaviour
{
    public int numCasilla;
    static public int Num;
    public Sprite bien;
    public Sprite mal;
    private Sprite SioNo;
    static public bool taBien;
    private bool tapado;
    public Sprite Tapado;
    public VariablesBoton[] VariableDeBoton;
    public int posicionBien;
    public bool turnoIA;
    public int NlInt;
    private string NombreBoton;
    private int LimSuperior;
    private int Liminferior;
    public Sprite Ganador;
    public GameObject tu;
    public Sprite Perdedor;
    public bool buffo;

    public void Start()
    {
        Restart(2);
    }

    public void Restart(int inteligencia)
    {
        Liminferior = 1;
        LimSuperior = 10;

        NlInt = inteligencia;
        int i = 0;
        foreach (VariablesBoton s in VariableDeBoton)
        {
            s.Ganador = false;
            s.Presionado = false;
            Button mybutton = GameObject.Find("Button" + (i + 1)).GetComponent<Button>();
            mybutton.interactable = true;
            Animator MyAnim = GameObject.Find("Button" + (i + 1)).GetComponent<Animator>();
            MyAnim.Play("Normal");
            MyAnim.SetBool("Winner", false);
            i++;
        }
        if (inteligencia == 3)
        {
            posicionBien = Random.Range(1, 10);
        }
        else
        {
            posicionBien = Random.Range(0, 10);
        }

        VariableDeBoton[posicionBien].Ganador = true;
        posicionBien = posicionBien + 1;

        Animator Anim = GameObject.Find("Button" + posicionBien).GetComponent<Animator>();
        Anim.SetBool("Winner", true);
        gameObject.SetActive(true);
    }

    public void ClickButton()
    {
        if (turnoIA)
        {
            VariablesBoton VariablesTemporal = GameObject.Find(NombreBoton).GetComponent<VariablesBoton>();
            if (VariablesTemporal.Presionado == false)
            {
                VariablesTemporal = GameObject.Find(NombreBoton).GetComponent<VariablesBoton>();
                Button mybutton = GameObject.Find(NombreBoton).GetComponent<Button>();
                mybutton.interactable = false;
                if (VariablesTemporal.Ganador == true)
                {
                    /*int i = 0;
                    foreach (VariablesBoton s in VariableDeBoton)
                    {
                        Button botonTemporal = GameObject.Find("Button" + (i + 1)).GetComponent<Button>();
                        botonTemporal.interactable = false;
                        i = i - 1;
                    }*/
                    Invoke(nameof(loose), 1f);
                }
                VariablesTemporal.Presionado = true;
                turnoIA = false;
            }
        }
        else
        {
            VariablesBoton VariablesTemporal = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<VariablesBoton>();
            if (VariablesTemporal.Presionado == false)
            {
                VariablesTemporal = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<VariablesBoton>();
                Button mybutton = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Button>();
                mybutton.interactable = false;
                if (VariablesTemporal.Ganador == true)
                {
                    /*int i = 0;
                    foreach (VariablesBoton s in VariableDeBoton)
                    {
                        Button botonTemporal = GameObject.Find("Button" + (i + 1)).GetComponent<Button>();
                        botonTemporal.interactable = false;
                        i = i + 1;
                    }*/
                    Invoke(nameof(Win), 1f);
                }
                VariablesTemporal.Presionado = true;
                turnoIA = true;

                Invoke(nameof(IA), 0.3f);
            }
        }
    }

    void Win()
    {
        SceneManager.LoadScene("victoriaMedio");
        tu.SetActive(false);
        Time.timeScale = 1;
        //GameObject.Find("personaje").SendMessage("bonus");
    }

    void loose()
    {
        SceneManager.LoadScene("derrota");
        tu.SetActive(false);
        Time.timeScale = 1;
    }

    void IA()
    {
        switch (NlInt)
        {
            case 1:
                int i = 0;
                foreach (VariablesBoton item in VariableDeBoton)
                {
                    if (item.Presionado == false && turnoIA == true)
                    {
                        Button miBotton = GameObject.Find("Button" + (i + 1)).GetComponent<Button>();
                        NombreBoton = miBotton.name;
                        miBotton.onClick.Invoke();
                    }
                    i = i + 1;
                }
                break;
            case 2:
                int u = 0;
                while (Liminferior <= LimSuperior)
                {
                    u = ((LimSuperior + Liminferior) / 2);

                    if (u < posicionBien)
                    {
                        Liminferior = u + 1;
                    }
                    else if (u > posicionBien)
                    {
                        LimSuperior = u - 1;
                    }
                    else
                    {
                        if (turnoIA)
                        {
                            Button miBotton = GameObject.Find("Button" + (u)).GetComponent<Button>();
                            NombreBoton = miBotton.name;
                            miBotton.onClick.Invoke();
                        }
                        break;
                    }
                    if (turnoIA)
                    {
                        Button miBotton = GameObject.Find("Button" + (u)).GetComponent<Button>();
                        NombreBoton = miBotton.name;
                        miBotton.onClick.Invoke();
                    }
                }
                break;
            case 3:
                while (Liminferior < LimSuperior)
                {
                    int Mint = Liminferior + ((LimSuperior - Liminferior) / 3);
                    int Msup = LimSuperior - ((LimSuperior - Liminferior) / 3);
                    if (Mint == posicionBien)
                    {
                        if (turnoIA)
                        {
                            Button miBotton = GameObject.Find("Button" + (Mint)).GetComponent<Button>();
                            NombreBoton = miBotton.name;
                            miBotton.onClick.Invoke();
                        }
                        break;
                    }
                    else if (Msup == posicionBien)
                    {
                        if (turnoIA)
                        {
                            Button miBotton = GameObject.Find("Button" + (Msup)).GetComponent<Button>();
                            NombreBoton = miBotton.name;
                            miBotton.onClick.Invoke();
                        }
                        break;
                    }
                    else if (Mint > posicionBien)
                    {
                        if (turnoIA)
                        {
                            Button miBotton = GameObject.Find("Button" + (Mint)).GetComponent<Button>();
                            NombreBoton = miBotton.name;
                            miBotton.onClick.Invoke();
                        }
                        LimSuperior = Mint - 1;
                    }
                    else if (Msup < posicionBien)
                    {
                        if (turnoIA)
                        {
                            Button miBotton = GameObject.Find("Button" + (Msup)).GetComponent<Button>();
                            NombreBoton = miBotton.name;
                            miBotton.onClick.Invoke();
                        }
                        Liminferior = Msup + 1;
                    }
                    else
                    {
                        Liminferior = Mint + 1;
                        LimSuperior = Msup - 1;
                    }
                }
                break;
        }
    }
}