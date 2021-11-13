using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rigid2D;
    public float speed;

    //重生点
    public GameObject SpawnPoint;

    //玩家的生命以及生命显示
    public static int LifeNum = 3;
    public GameObject LifeNumCurrernt;

    //场景切换
    public GameObject SenceManager;


    private void Awake()
    {
        Rigid2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 acc2D = new Vector2();

        Vector3 acc = Input.acceleration;
/*        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");*/
        var vertical = acc.x * Mathf.Sqrt(speed);//对speed开根号
        var horizontal = acc.y * Mathf.Sqrt(speed);
        acc2D = new Vector2(vertical, horizontal);
        Rigid2D.AddForce(acc2D);

        LifeNumCurrernt.GetComponent<TMP_Text>().text = LifeNum.ToString();
    }

    /*    void FixedUpdate()
        {
            Vector2 acc2D = new Vector2();

            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            acc2D = new Vector2(horizontal, vertical);
            Rigid2D.AddForce(acc2D);

            LifeNumCurrernt.GetComponent<TMP_Text>().text = LifeNum.ToString();
        }*/

    public void LifeNumber()
    {
        if(LifeNum > 0f)
        {
            LifeNum--;

            //Debug.Log("LifeNum = " + LifeNum);
        }
        if(LifeNum == 0f)
        {
            Debug.Log("DIE");

            Rigid2D.transform.SetPositionAndRotation(SpawnPoint.transform.position, Quaternion.identity);

            LifeNum = 3;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            LifeNum = 3;

            SenceManager.GetComponent<SceneSwitchManager>().NextLevel();
        }
    }


}