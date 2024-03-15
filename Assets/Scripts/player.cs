using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class player : MonoBehaviour
{
    Transform salida;

    float proximoDisparo = 0f;

    public GameObject Vidas;

    public int vidasActual;

    public Texture vidaMala;

    float tiempoDeDisparo = 0.3f;

    public GameObject bala;

    public Text puntuacionText;

    int puntuacionPlayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        salida =
            gameObject.transform.GetChild(0).GetChild(0).GetChild(0).transform;
        vidasActual = 2;
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

    // Si toca un premio
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Premio"))
        {
            actualizarPuntuacion(10);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("salida"))
        {
            SceneManager.LoadScene("Victoria");
        }
        if (other.gameObject.CompareTag("Enemigo"))
        {
            // Cambiar el comportamiento del collider
            other.isTrigger = false;
            if (vidasActual > 0)
            {
                Vidas
                    .transform
                    .GetChild(vidasActual)
                    .GetComponent<RawImage>()
                    .texture = vidaMala;
            }
            else
            {
                SceneManager.LoadScene("Fin");
            }

            vidasActual--;

            // Esperarse 1 segundo
            StartCoroutine(ReactivarCollider(other));
        }
    }

    // Metodo para actualizar la puntuacion
    public void actualizarPuntuacion(int puntos)
    {
        puntuacionPlayer += puntos;
        puntuacionText.text = "Puntuación: " + puntuacionPlayer;
    }

    IEnumerator ReactivarCollider(Collider other)
    {
        yield return new WaitForSeconds(1);
        other.isTrigger = true;
    }
}
