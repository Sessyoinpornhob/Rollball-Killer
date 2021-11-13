using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMove : MonoBehaviour
{
    //�������ݷ�����ѭ���ƶ���[�ƶ�-ײǽ-ת180��]-�ƶ�
    //�����Ͳ��ж��ˣ�������������
    Rigidbody2D rb;
    public float Speed;
    public float turnSpeed;

    public bool directionUp = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(directionUp == false)
        {
            rb.velocity = Vector2.down * Speed;
        }
        if (directionUp == true)
        {
            rb.velocity = Vector2.up * Speed;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DownWall")
        {
            Debug.Log("hit downwall");

            transform.DORotate(new Vector3(0, 0f, -0f), turnSpeed);

            Debug.Log("turn up");

            directionUp = true;
        }

        if (collision.gameObject.tag == "UpWall")
        {
            Debug.Log("hit upwall");

            transform.DORotate(new Vector3(0, 0f, -180f), turnSpeed);

            directionUp = false;

        }
    }



}
