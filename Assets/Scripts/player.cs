using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Transform salida;

    float proximoDisparo = 0f;

    float tiempoDeDisparo = 0.3f;

    public GameObject bala;

    // Start is called before the first frame update
    void Start()
    {
        salida =
            gameObject.transform.GetChild(0).GetChild(0).GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= proximoDisparo && Input.GetMouseButtonDown(0))
        {
            proximoDisparo = Time.time + tiempoDeDisparo;
            GameObject balaInstanciada =
                Instantiate(bala, salida.position, salida.rotation);

            // rotar la bala para que salga con la punta por delante
            balaInstanciada.transform.Rotate(90, 0, 0);
        }
    }
}
