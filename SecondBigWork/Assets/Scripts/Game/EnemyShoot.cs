using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
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
        if (t > 0.5f)
        {
            t = 0;
            if (this.name.Contains("1"))//transform.childCount 有多少子物体
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    GameObject b1 = Instantiate(bullets[0]);
                    b1.transform.position = transform.GetChild(i).position;
                }
            }
            if (this.name.Contains("2"))//transform.childCount 有多少子物体
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    GameObject b1 = Instantiate(bullets[1]);
                    b1.transform.position = transform.GetChild(i).position;
                }
            }
            if (this.name.Contains("3"))//transform.childCount 有多少子物体
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    GameObject b1 = Instantiate(bullets[2]);
                    b1.transform.position = transform.GetChild(i).position;
                }
            }
        }
    }
}
