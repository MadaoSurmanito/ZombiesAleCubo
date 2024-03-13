using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gestorVidas : MonoBehaviour
{
    public float Vida = 5f;

    public float maxVida = 5f;

    public UnityEvent meHanTocado;

    public UnityEvent heMuerto;

    void tocado(float fuerza)
    {
        Vida -= fuerza;
        meHanTocado.Invoke();
        if (Vida <= 0)
        {
            heMuerto.Invoke();
        }
    }
}
