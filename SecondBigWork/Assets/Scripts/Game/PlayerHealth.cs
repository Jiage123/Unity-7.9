using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider hpslider;
    float hp = 100;
    public GameObject[] ex = new GameObject[3];
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        hpslider.maxValue = 100;
        hpslider.value = 100;
    }
    private void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.tag == "Enemy")
        {
            ShowScore.score += 15;
            GameObject enemyEx = Instantiate(ex[0]);
            enemyEx.transform.position = o.gameObject.transform.position;
            hp -= 10;
            if (o.name.Contains("1"))
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio(2);
            }
            else
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio(3);
            }
            Destroy(o.gameObject);
        }
        if (o.gameObject.tag == "EnemyBullet")
        {
            ShowScore.score += 3;
            GameObject enemyBulletEx = Instantiate(ex[1]);
            enemyBulletEx.transform.position = o.gameObject.transform.position;
            hp -= 5;
            Destroy(o.gameObject);
        }
        if (o.gameObject.name.Contains("goods4"))
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio(6);
            hp += 20;
            Destroy(o.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        hpslider.value = hp;
        if (hp <= 0)
        {
            GameObject playerEx = Instantiate(ex[2]);
            playerEx.transform.position = transform.position;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio(4);
            gameOver.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
