using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    float t = 0;
    public GameObject playerBullet;
    AudioSource au;
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[3];
    int num = 1;
    // Start is called before the first frame update
    void Start()
    {
        au = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void OnTriggerEnter(Collider o)// GameObject.Find() 寻找面板上活着的物体
    {
        if (o.gameObject.name.Contains("goods1"))
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio(0);
            spriteRenderer.sprite = sprites[0];
            num = 1;
            Destroy(o.gameObject);
            
        }
        if (o.gameObject.name.Contains("goods2"))
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio(0);
            spriteRenderer.sprite = sprites[1];
            num = 2;
            Destroy(o.gameObject);
        }
        if (o.gameObject.name.Contains("goods3"))
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio(0);
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio(1);
            spriteRenderer.sprite = sprites[2];
            num = 4;
            Destroy(o.gameObject);
        }
        
      

    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (t > 0.2f)
        {
            au.Play();
            t = 0;
            if (num == 1)
            {
                GameObject bullet = Instantiate(playerBullet);//根据（预制体）生成
                bullet.transform.position = transform.GetChild(0).position;
            }
            if (num == 2)
            {
                for (int i = 1; i < 3; i++)
                {
                    GameObject bullet = Instantiate(playerBullet);
                    bullet.transform.position = transform.GetChild(i).position;
                }
            }
            if (num == 4)
            {
                for (int i = 1; i < 5; i++)
                {
                    GameObject bullet = Instantiate(playerBullet);
                    bullet.transform.position = transform.GetChild(i).position;
                }
            }

        }



    }
}
