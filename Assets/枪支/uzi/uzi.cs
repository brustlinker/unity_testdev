using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uzi : MonoBehaviour
{


    private float 射击间隔时间 = 1f;
    private bool canfire = true;

    public GameObject 子弹预设;



    // Update is called once per frame
    void Update()
    {

        //如果左键摁下，而且可以进行攻击，那么生成子弹

        if (Input.GetButton("Fire1")
            && canfire)
        {
            开始发射子弹和调整canfire逻辑();
        }

    }

    void 开始发射子弹和调整canfire逻辑()
    {
        生成子弹();
        canfire = false;
        StartCoroutine("间隔一段时间以后设置canfire");
    }

    void 生成子弹()
    {
        Debug.Log("发射子弹");
        //生成子弹
        //设置子弹的属性
    }


    IEnumerator 间隔一段时间以后设置canfire()
    {
        //Loop indefinitely
        while (true)
        {
            //Wait for it to be time to fire another shot
            yield return new WaitForSeconds(射击间隔时间);

            canfire = true;
            StopCoroutine("Shoot");
        }
    }
}
