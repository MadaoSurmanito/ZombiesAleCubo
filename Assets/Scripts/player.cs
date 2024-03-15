using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Transform salida;

    float proximoDisparo = 0f;

    float tiempoDeDisparo = 0.3f;

    public GameObject bala;

    public Text puntuacionText;

    int puntuacionPlayer = 0;

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
    }

        // Metodo para actualizar la puntuacion
    public void actualizarPuntuacion(int puntos)
    {
        puntuacionPlayer += puntos;
        puntuacionText.text = "Puntuación: " + puntuacionPlayer;
    }
}
