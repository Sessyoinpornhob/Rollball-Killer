using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D Rigid2D;
    public float speed;

    private void Awake()
    {
        Rigid2D = gameObject.GetComponent<Rigidbody2D>();
    }

/*    private void FixedUpdate()
    {
        Vector2 acc2D = new Vector2();

        Vector3 acc = Input.acceleration;
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var vertical = acc.x * Mathf.Sqrt(speed);//¶Ôspeed¿ª¸ùºÅ
        var horizontal = acc.y * Mathf.Sqrt(speed);
        acc2D = new Vector2(vertical, horizontal);
        Rigid2D.AddForce(acc2D);
    }*/

    void FixedUpdate()
    {
        Vector2 acc2D = new Vector2();

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        acc2D = new Vector2(horizontal, vertical);
        Rigid2D.AddForce(acc2D);
    }

}