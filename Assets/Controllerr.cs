using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllerr : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rigid;

    Vector3 horiz;
    Vector3 vertical;

    // Start is called before the first frame update
    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        horiz = new Vector3(-(Input.GetAxis("Horizontal")),0,0);
        vertical = new Vector3(0,0, -(Input.GetAxis("Vertical")));
    }
    void FixedUpdate()
    {
        rigid.AddForce(horiz * speed);
        rigid.AddForce(vertical * speed);
    }
}
