using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemySightController : MonoBehaviour
{
    [SerializeField] GameObject _player;

    //Enemy看到了Player = 从Enemy向Player发射的射线能打到player上 + Player在Enemy的视线碰撞区内
    [SerializeField] bool Isinsight = false;
    [SerializeField] bool IsRaid = false;
    [SerializeField] bool Isseen = false;

    //Enemy看到Player后，视线灯的颜色由绿变红
    Light2D _SightLight;
    Color SightLightColor;
    Color SightLightColorGreen;
    [SerializeField] private float timer = 0f;

    //处理玩家的生命信息的重要游戏物体和脚本
    //public PlayerController CS_PlayerController;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _SightLight = GetComponent<Light2D>();

        Color SightLightColorGreen = new Color(0.258f, 0.830f, 0.191f, 1f);

        Color SightLightColor = _SightLight.color;
        
        //Debug.Log(SightLightColor);
    }


    private void Update()
    {
        RaytoPlayer();

        if (IsRaid == true && Isinsight == true)
        {
            Isseen = true;

            if (SightLightColor == SightLightColorGreen)
            {
                Timer(0.1f);

                _SightLight.color = new Color(212 / 255f, 49 / 255f, 70 / 255f, timer);
            }
        }
        else
        {
            Isseen = false;

            timer = 0f;

            _SightLight.color = new Color(0.258f, 0.830f, 0.191f, 1f);
        }

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

            if (IsRaid == true)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().LifeNumber();//这种方法有效但是效率较低
            }

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Isinsight = false;
        }
    }


    private void Timer(float _seconds)
    {
        float _multiple = 1 / _seconds;

        if (timer <= 1)
        {
            timer += Time.deltaTime * _multiple;
        }
    }

}
