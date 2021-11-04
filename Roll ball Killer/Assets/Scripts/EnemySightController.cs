using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySightController : MonoBehaviour
{
    GameObject _player;

    //Enemy������Player = ��Enemy��Player����������ܴ�player�� + Player��Enemy��������ײ����
    public bool Isinsight = false;
    public bool IsRaid = false;
    public bool Isseen = false;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        RaytoPlayer();

        if (IsRaid == true && Isinsight == true)
        {
            Isseen = true;
        }
        else
        {
            Isseen = false;
        }
        Debug.Log("Isseen = " + Isseen);

    }

    //�����������֮���Ƿ����ǽ�ڵ��ڵ�
    public void RaytoPlayer()
    {
        Vector3 EnemytoPlayer = (_player.transform.position - transform.position);

        //2D���̲�Ҫʹ��ray�������ʹ��ray2D������������ֵ�bug����>����һ������ͷ�ó��Ľ���
        Ray2D ray = new Ray2D(this.transform.position, EnemytoPlayer);

        RaycastHit2D info = Physics2D.Raycast(this.transform.position, EnemytoPlayer, 100f);

        if (Physics2D.Raycast(this.transform.position, EnemytoPlayer, 100f))
        {
            if (info.collider.gameObject.tag == "Player")
            {
                IsRaid = true;
            }
            else
            {
                IsRaid = false;
            }
        }
    }

    //���������д��2D�����޷���������Ч����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Isinsight = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Isinsight = false;
        }
    }


}
