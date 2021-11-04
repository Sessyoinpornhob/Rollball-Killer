using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySightController : MonoBehaviour
{
    GameObject _player;

    //Enemy看到了Player = 从Enemy向Player发射的射线能打到player上 + Player在Enemy的视线碰撞区内
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

    //检测玩家与敌人之间是否存在墙壁等遮挡
    public void RaytoPlayer()
    {
        Vector3 EnemytoPlayer = (_player.transform.position - transform.position);

        //2D工程不要使用ray，请务必使用ray2D，否则会出现奇怪的bug——>经过一下午挠头得出的结论
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

    //这里如果不写“2D”是无法正常触发效果的
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
