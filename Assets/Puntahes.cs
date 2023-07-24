using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puntahes : MonoBehaviour
{
    public int playerscore;

    public AudioSource sonidodeRespawn;

    public int entradas;


    /* game over tiene 4 estados:
     * 0 = el juego no termino
     * 1 = el tiempo se acabó
     * 2 = el puntaje llego a 0
     * 3 = dos pelotas chocaron
    */


    void Start()
    {
        playerscore = 10;
        entradas = 0;
    }
    void Update()
    {   
        if (gameObject.transform.position.y <= -2)
        {
                transform.position = new Vector3(0, 3, 0);
                sonidodeRespawn.Play();
        }
    }
}
