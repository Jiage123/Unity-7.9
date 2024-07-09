using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Slider hpslider;
    float hp = 100;
    public GameObject[] bossEx = new GameObject[2];
    public static int num = 1;
    // Start is called before the first frame update
    void Start()
    {
        hpslider.maxValue = 100 * num;
        hpslider.value = 100 * num;
        hp *= num;
    }
    private void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.name.Contains("PlayerBullet"))
        {
            hp -= 5;
            Instantiate(bossEx[0]).transform.position = o.gameObject.transform.position;
            Destroy(o.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        hpslider.value = hp;
        if (hp <= 0)
        {
            Instantiate(bossEx[1]).transform.position = transform.position;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio(5);
            num++;
            CreateEnemy.isBoss = false;
            ShowScore.score += 1000;
            Destroy(this.gameObject);
        }
    }
}
