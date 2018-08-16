using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class 子弹 : MonoBehaviour
    {

        //弓箭移动速度
        private float 移动速度 = 10f;

        //超时删除
        private float 存在时间 = 10f;
        private float 定时器 = 0f;

        //移动
        private Vector3 飞行方向;

        //碰撞到东西爆炸
        public Texture2D 爆炸贴图;
        private bool 已经爆炸 = false;

        private float 切割宽度 = 16;
        private float 切割高度 = 16;

        private float 攻击力 = 5f;


        // Use this for initialization
        void Start()
        {
            定时器 = 存在时间;
        }


        public void 初始化方向向量(Vector3 方向向量)
        {
            this.飞行方向 = 方向向量.normalized;

            //设置旋转方向
            float 弧度表示的旋转角度 = Mathf.Atan2(方向向量.y, 方向向量.x);
            float 角度表示的旋转角度 = Mathf.Rad2Deg * 弧度表示的旋转角度;
            this.transform.rotation = Quaternion.Euler(0, 0, 角度表示的旋转角度);
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            定时器 -= Time.deltaTime;

            //超出存活时间
            if (定时器 < 0)
            {
                爆炸();

            }
            else if (!已经爆炸)
            {
                //向指定方向移动
                移动();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {

            //如果已经爆炸，不再检测，防止爆炸的效果造成多段伤害
            if (已经爆炸)
            {
                return;
            }

            //与墙碰撞
            /*
            if (other.tag == 标签.标签_墙.ToString())
            {
                爆炸();
            }
            */

            //与玩家碰撞

            /*
            if (other.tag == 标签.标签_玩家.ToString())
            {
                //发送伤害消息
                if (other.GetComponent<BoxCollider2D>().tag == 标签.标签_玩家.ToString())
                {
                    //调用物体的方法
                    other.GetComponent<BoxCollider2D>().SendMessage("被攻击", 攻击力);
                }

                //
                爆炸();
            }
            */


        }

        private void 爆炸()
        {
            //获精灵显示器
            SpriteRenderer 贴图渲染器 = this.GetComponent<SpriteRenderer>();
            Sprite 切割图片 = Sprite.Create(爆炸贴图, new Rect(0, 0, 切割宽度, 切割高度), new Vector2(0.5f, 0.5f));//注意居中显示采用0.5f值
            贴图渲染器.sprite = 切割图片;

            //删除自己
            Destroy(gameObject, 1f);

            //设置爆炸变量不在移动
            已经爆炸 = true;

            //播放爆炸音效

        }


        private void 移动()
        {
            this.transform.position += 飞行方向 * Time.deltaTime * 移动速度;
        }//移动

    }//弓箭

