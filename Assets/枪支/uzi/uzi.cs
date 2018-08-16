using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uzi : MonoBehaviour
{


    private float 上一次执行时间=0f;

    public GameObject 子弹预制;
    private float nextFire = 0.0F;
    private float fireRate = 0.1F;


    public AudioClip 枪响声;
    public AudioSource audioSource;



    // Update is called once per frame
    void FixedUpdate()
    {

        //如果左键摁下，而且可以进行攻击，那么生成子弹
        if (Input.GetButton("Fire1")
            && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            测试两次时间间隔();

            播放特效();
            播放音效();
            生成子弹();
        }

    }

    void 测试两次时间间隔()
    {
        //测试两颗子弹发射的间隙
        float 当前时间 = Time.time;
        Debug.Log(当前时间 - 上一次执行时间);
        上一次执行时间 = 当前时间;
    }


    void 播放特效()
    {

    }

    void 播放音效()
    {
        audioSource.volume = Random.Range(0.2f, 1f);
        audioSource.Play();
    }


    void 生成子弹()
    {

        GameObject 子弹 = GameObject.Instantiate(子弹预制);
        子弹.transform.position = transform.position+偏移位置();
        子弹 子弹脚本 = 子弹.GetComponent<子弹>();
        子弹脚本.初始化方向向量(生成移动方向());
    }

    Vector3 生成移动方向()
    {
        return new Vector3(-1,0,0);
    }

    Vector3 偏移位置()
    {
        return new Vector3(-0.16f, 0.122f, 0);
    }


}
