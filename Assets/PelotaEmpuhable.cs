using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaEmpuhable : MonoBehaviour
{
    public Puntahes player;
    public AudioSource pelotacae;
    
    public GameObject pelota1;
    public GameObject pelota2;
    public GameObject pelota3;

    public Transform posresp1;
    public Transform posresp2;
    public Transform posresp3;

    private Rigidbody rb1;
    private Rigidbody rb2;
    private Rigidbody rb3;

    void Start()
    {
        rb1 = pelota1.GetComponent<Rigidbody>();
        rb2 = pelota2.GetComponent<Rigidbody>();
        rb3 = pelota3.GetComponent<Rigidbody>();

    }

    void Update()
    {   if(pelota1 != null && posresp1 != null)
        {
            if (pelota1.transform.position.y <= -2)
            {
                player.playerscore--;
                pelota1.transform.position = posresp1.position;
                returnToZero(rb1);
                pelotacae.Play();
            }
        }

        if (pelota2 != null && posresp2 != null)
        {
            if (pelota2.transform.position.y <= -2)
            {
                player.playerscore--;
                pelota2.transform.position = posresp2.position;
                returnToZero(rb2);
                pelotacae.Play();
            }
        }
            

        if (pelota3 != null && posresp3 != null)
        {
            if (pelota3.transform.position.y <= -2)
            {
                player.playerscore--;
                pelota3.transform.position = posresp3.position;
                returnToZero(rb3);
                pelotacae.Play();
            }
        }
    }
 void returnToZero(Rigidbody rigido)
    {
        rigido.velocity = Vector3.zero;
        rigido.angularVelocity = Vector3.zero;
        rigido.rotation = Quaternion.identity;
    }
}
