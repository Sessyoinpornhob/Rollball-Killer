using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    GameObject _player;
    public static int EnemyNum = 0;
    //CircleCollider2D EnemyCollider2D;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        EnemyNum++;
    }

    void OnCollisionEnter2D(Collision2D collision)//[2D]���������Ҫ
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("kill");
            gameObject.SetActive(false);
            EnemyNum--;
        }
    }
    //player��ײ��enemy�Ժ�enemy���ص�

    public void MovetoPlayer()
    {
        Debug.Log("�û�");
    }

}
