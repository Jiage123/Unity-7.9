using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject[] bullets = new GameObject[3];
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 0.3f)
        {
            t = 0;
            for (int i = 0; i < 2; i++)
            {
                GameObject bullet = Instantiate(bullets[0]);
                bullet.transform.position = transform.GetChild(i).position;
                if (i == 0)
                {
                    bullet.transform.eulerAngles = new Vector3(-90, 0, 45);
                }
                if (i == 1)
                {
                    bullet.transform.eulerAngles = new Vector3(-90, 0, -45);
                }
                Destroy(bullet.GetComponent<EnemyBulletMove>());//销毁子弹身上的移动脚本
                bullet.AddComponent<BulletDestroy>();//添加自身销毁脚本
                bullet.GetComponent<Rigidbody>().AddForce(transform.GetChild(i).up * 200);
            }
            for (int i = 2; i < 4; i++)
            {
                GameObject bullet = Instantiate(bullets[1]);
                bullet.transform.position = transform.GetChild(i).position;
            }
            for (int i = 4; i < 6; i++)
            {
                GameObject bullet = Instantiate(bullets[2]);
                bullet.transform.position = transform.GetChild(i).position;
            }
        }
    }
}
