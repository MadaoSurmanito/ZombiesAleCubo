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
