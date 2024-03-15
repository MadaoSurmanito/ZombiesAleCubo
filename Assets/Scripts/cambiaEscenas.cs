using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiaEscenas : MonoBehaviour
{
    
    public void escenaJuego()
    {
        SceneManager.LoadScene("Escena1");
    }

    public void escenaMenu()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void salir()
    {
        Application.Quit();
    }
    
    

}
