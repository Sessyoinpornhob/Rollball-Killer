using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    GameObject _player;
    public static int EnemyNum = 0;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        
        EnemyNum++;
        //Debug.Log(EnemyNum);
    }


    void OnCollisionEnter2D(Collision2D collision)//[2D]���������Ҫ
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("kill");

            EnemyNum--;

            Destroy(gameObject, 0.2f);
            //gameObject.SetActive(false);
        }
    }
    //player��ײ��enemy�Ժ�enemyɾ��

    public void MovetoPlayer()
    {
        Debug.Log("�û�");
    }

}
