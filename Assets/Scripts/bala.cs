using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocidad = 5.0f;

    public float valorHerida = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float movDitancia = Time.deltaTime * velocidad;
        transform.Translate(Vector3.up * movDitancia);
        // Si la bala no ha tocado nada en 3 segundos, se destruye
        Destroy(gameObject, 3);
    }

    void OnTriggerEnter(Collider other)
    {
        other
            .SendMessage("tocado",
            valorHerida,
            SendMessageOptions.DontRequireReceiver);
        Destroy (gameObject);
    }
}
