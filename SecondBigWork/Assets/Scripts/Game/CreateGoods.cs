using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGoods : MonoBehaviour
{
    public GameObject[] goods = new GameObject[4];
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 2)
        {
            t = 0;
            GameObject good = Instantiate(goods[Random.Range(0, 4)]);
            good.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), 1, 6);
        }

    }
}
