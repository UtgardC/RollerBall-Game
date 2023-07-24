using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OchentaPerc : MonoBehaviour
{
    public ManagerDeJuego magnani;
    private float rotationSpeed;
    private float pasadosochenta;
    private float calculo;
    public float proporcionAngular = 100f; // esta variable define la escala de rotacion, valores mas grandes devolverán menores velocidades.

    void Start()
    {   
        rotationSpeed = 0f;
        pasadosochenta = ((magnani.startingTime * 20f) / 100f);
    }
    void Update()
    {
        if ( (magnani.timeRemaining <= pasadosochenta) && (magnani.onGame) )
        {
            //funcion exponencial para la velocidad de rotacion en funcion del tiempo
            calculo = (pasadosochenta - magnani.timeRemaining);
            rotationSpeed = (Mathf.Pow(calculo, 2f) / proporcionAngular);
        }
    }
    void FixedUpdate()
    {
        if ((magnani.timeRemaining <= pasadosochenta) && (magnani.onGame)) transform.Rotate(Vector3.up, rotationSpeed, Space.World);
    }
}
