using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    public GameObject[] ex = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.tag == "Enemy")
        {
            ShowScore.score += 15;
            GameObject enemyEx = Instantiate(ex[0]);
            enemyEx.transform.position = o.gameObject.transform.position;
            if (o.name.Contains("1"))
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio(2);
            }
            else
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio(3);
            }
            Destroy(o.gameObject);
            Destroy(this.gameObject);
        }
        if (o.gameObject.tag == "EnemyBullet")
        {
            ShowScore.score += 3;
            GameObject enemyBulletEx = Instantiate(ex[1]);
            enemyBulletEx.transform.position = o.gameObject.transform.position;
            Destroy(o.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0.09f, Space.World);
        if (transform.position.z > 7)
        {
            Destroy(this.gameObject);//销毁自己
        }
    }
}
