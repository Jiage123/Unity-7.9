using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public Image UI;
    public Text text;
    public GameObject Handitem;//ʰȡ����õ����ϵ�λ��
    public GameObject item;//Ҫ��ʰȡ����Ʒ
    public float radius = 2.5f;//ʰȡ��Ʒ�ķ�Χ�뾶
    private bool isPick;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Handitem.SetActive(false);
        UI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Handitem.SetActive(true);
                item.SetActive(false);
                //isPick = !isPick;
                //if (isPick)
                //{
                //    text.text = "F ����";
                //    //isPick = true;
                //    Handitem.SetActive(true);
                //    item.SetActive(false);

                //}
                //else
                //{
                //    text.text = "F ʰȡ";

                //    Handitem.SetActive(false);
                //    item.SetActive(true);

                //}

            }
            //if (gameObject.CompareTag("Player"))
            //{
               
            //}
            
        }
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        UI.gameObject.SetActive(true);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        UI.gameObject.SetActive(false);
    //    }
    //}
}

