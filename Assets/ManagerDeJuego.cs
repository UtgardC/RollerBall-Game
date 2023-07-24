using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManagerDeJuego : MonoBehaviour
{
    public Puntahes player;
    public Controllerr playermov;
    public GameObject playerBall;
    private Rigidbody rig1;


    public PelotaEmpuhable pelotas;
    public OchentaPerc plataforma;
    public Text txscreen;
    public GameObject marcoCentral;
    public int gameover;

    public timer tiempo;
    public GameObject conteopuntos;

    public AudioSource ganaste;

    public AudioSource perdiste;
    

    public float startingTime = 50.0f;
    public float timeRemaining;
    public bool onGame;
    public bool win;



    void Start()
    {
        Time.fixedDeltaTime = 0.02f;
        marcoCentral.SetActive(false);
        timeRemaining = startingTime;
        onGame = true;
        conteopuntos.SetActive(true);
        gameover = 0;
        rig1 = playerBall.GetComponent<Rigidbody>();


    }

    void Update()
    {
        if (player.playerscore == 0) gameover = 2;

        if (player != null && player.entradas >= 3 && !(win))
        {   

            onGame = false;
            win = true;
            marcoCentral.SetActive(true);
            ganaste.Play();

            conteopuntos.SetActive(false);
            freezeBall(rig1, playerBall, playermov);

            txscreen.text = ( "GANASTE\n" + "\nTiempo Empleado: " + ((startingTime - timeRemaining).ToString("0")) + "s" +" Puntaje total: " + ((player.playerscore).ToString("0")) );
        }


        if(gameover > 0 && onGame)
        {
                perdiste.Play();

            conteopuntos.SetActive(false);
            marcoCentral.SetActive(true);
            freezeBall(rig1, playerBall, playermov);

            if (gameover == 1)
            {
                txscreen.text = ( "PERDISTE\n" + "Se acabó el tiempo" + "\nPuntaje total: " + ((player.playerscore).ToString("0")) );
            }
            else if (gameover == 2)
            {
                txscreen.text = ( "PERDISTE\n" + "El puntaje llegó a 0" + "\nTiempo Empleado: " + ((startingTime - timeRemaining).ToString("0")) + "s");
            }
            else if (gameover == 3)
            {
                txscreen.text = ( "PERDISTE\n" + "Dos pelotas chocaron" + "\nTiempo Empleado: " + ((startingTime - timeRemaining).ToString("0")) + "s" + "\nPuntaje total: " + ((player.playerscore).ToString("0")) );
            }

            onGame = false;
            Destroy(pelotas.pelota1);
            Destroy(pelotas.pelota2);
            Destroy(pelotas.pelota3);
        }
    }
    void freezeBall(Rigidbody rigido, GameObject jugapelota, Controllerr playerrsp)
    {
        rigido.velocity = Vector3.zero;
        rigido.angularVelocity = Vector3.zero;
        rigido.rotation = Quaternion.identity;
        playerrsp.speed = 0f;
        jugapelota.transform.position = Vector3.zero;
    }
}
