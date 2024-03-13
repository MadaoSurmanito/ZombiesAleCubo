using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigos : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent pathfinder;

    Transform target;

    float vidaRestante;

    public Image barraVida;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        pathfinder.SetDestination(target.position);
    }

    public void meHanTocado()
    {
        vidaRestante =
            GetComponent<gestorVidas>().Vida /
            GetComponent<gestorVidas>().maxVida;
        barraVida.transform.localScale = new Vector3(vidaRestante, 1, 1);
    }

    public void heMuerto()
    {
        Destroy (gameObject);
    }
}
