using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemySightController : MonoBehaviour
{
    [SerializeField] GameObject _player;

    //Enemy������Player = ��Enemy��Player����������ܴ�player�� + Player��Enemy��������ײ����
    [SerializeField] bool Isinsight = false;
    [SerializeField] bool IsRaid = false;
    [SerializeField] bool Isseen = false;

    //Enemy����Player�����ߵƵ���ɫ���̱��
    Light2D _SightLight;
    Color SightLightColor;
    Color SightLightColorGreen;
    [SerializeField] private float timer = 0f;

    //������ҵ�������Ϣ����Ҫ��Ϸ����ͽű�
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

            if (IsRaid == true)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().LifeNumber();//���ַ�����Ч����Ч�ʽϵ�
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
