using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    
    private bool timerIsRunning = false;

    public Text timerText; // used for showing countdown
    public Text puntajeText; // used for showing countdown

    public Puntahes player;
    public OchentaPerc evento;
    public ManagerDeJuego manani;

    void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        // Convert integer to string
        puntajeText.text = (player.playerscore).ToString("0");
        timerText.text = (manani.timeRemaining).ToString("0");

        if (timerIsRunning && manani.onGame)
        {
            if (manani.timeRemaining > 0)
            {
                manani.timeRemaining -= Time.deltaTime;
            }
            else
            {
                manani.gameover = 1;
                manani.timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}