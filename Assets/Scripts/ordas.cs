// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using UnityEngine.UIElements;

// public class Ordas : MonoBehaviour
// {
//     public ValoresEnemigos[] ordaEnemigos;

//     public ValoresEnemigos ordaActual;

//     float tiempoEspera = 0;

//     int numOrdaActual = 0;

//     int enemigosPorCrear = 0;

//     int enemigosParaMatar = 0;



//     // Texto para mostrar la orda actual
//     public Text ordaActualText;


//     public UnityEvent heMuerto;

//     // Start is called before the first frame update
//     void Start()
//     {
//         // Esperar 3 segundos antes de crear el primer enemigo
//         new WaitForSeconds(3);
//         NextOrda();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // Si hay enemigos por crear y ya paso el tiempo de espera
//         if (enemigosPorCrear > 0 && Time.time > tiempoEspera)
//         {
//             // Crear enemigo
//             this.enemigosPorCrear--; // Disminuir enemigos por crear
//             tiempoEspera = Time.time + ordaActual.spawnTime; // Actualizar tiempo de espera
//             GameObject enemigoParaCrear =
//                 Instantiate(ordaActual.tipoEnemigo,
//                 Vector3.zero,
//                 Quaternion.identity); // Crear enemigo
//         }
//     }

//     // Metodo para disminuir enemigos para matar
//     void EnemigoMuerto()
//     {
//         enemigosParaMatar--;
//         actualizarPuntuacion(10);
//         if (enemigosParaMatar == 0)
//         {
//             NextOrda();
//         }
//     }



//     void NextOrda()
//     {
//         // Si ordaEnemigos no tiene mas ordas
//         if (numOrdaActual >= ordaEnemigos.Length)
//         {
//             SceneManager.LoadScene("Victoria");
//         }
//         else
//         {
//             numOrdaActual++;
//             ordaActual = ordaEnemigos[numOrdaActual - 1];
//             enemigosPorCrear = ordaActual.numeroEnemigos;
//             enemigosParaMatar = ordaActual.numeroEnemigos;
//             tiempoEspera = Time.time + ordaActual.spawnTime;
//         }
//     }
// }
