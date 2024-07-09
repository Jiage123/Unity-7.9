using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject[] enemys = new GameObject[4];
    float t = 0;
    float time = 0;
    public static bool isBoss = false;

    void Start()
    {
        RestartGame(); // 在 Start 方法中调用重新开始游戏的逻辑
    }

    void Update()
    {
        if (!isBoss)
        {
            time += Time.deltaTime;
            if (time <= 10)
            {
                t += Time.deltaTime;
                if (t > 0.5f)
                {
                    t = 0;
                    GameObject enemy = Instantiate(enemys[Random.Range(0, 3)]);
                    enemy.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 1, 7);
                }
            }
            else
            {
                GameObject enemy = Instantiate(enemys[3]);
                enemy.transform.position = new Vector3(0, 1, 7);
                isBoss = true;
                time = 0;
            }
        }
    }

    // 重新开始游戏的方法
    public void RestartGame()
    {
        isBoss = false; // 重置是否为Boss标志位
        time = 0; // 重置生成敌人的时间
        t = 0; // 重置生成敌人的间隔时间
        // 可以添加其他需要重置的状态或变量
    }
}