using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class NpcMovent : MonoBehaviour
{

    public bool isHaveTalk; //��������-�Ƿ��жԻ�
    public List<Transform> movePath; // �ƶ���·��
    public MoveType moveType; // �ƶ�������-�̶�·��-���·��
    public GameObject panTipKeyDown; // ��ʾ���°����ı�
    public DialogWith panDialogue; // �Ի������
    public TextAsset asset; //�Ի����ļ�

    private NavMeshAgent nav;
    private Animator aim;
    private bool isCanShow; // �Ƿ�����ʾ�Ի�
    private Vector3 movePos; // �ƶ���Ŀ���
    private int indexPos = 0;
    private bool isChanged;

    private DialogWith currentDialoguePanel; // ���ڸ��ٵ�ǰ�ĶԻ����
    
    private bool isTalking = false;// �Ƿ����ڶԻ���

    void Start()
    {
        nav = this.GetComponent<NavMeshAgent>();
        aim = this.GetComponent<Animator>();
        movePos = movePath[0].position;
    }


    void Update()
    {
        this.transform.LookAt(movePos);
        nav.SetDestination(movePos);
        // �����ƶ����͸���Ŀ���
        if (nav.remainingDistance < 0.5f)
        {
            switch (moveType)
            {
                case MoveType.RandomMv:
                    if (!isChanged)
                    {
                        movePos = movePath[Random.Range(0, movePath.Count)].position;
                        isChanged = true;
                    }
                    break;

                case MoveType.LineMv:
                    if (indexPos == movePath.Count) indexPos = 0;
                    if (!isChanged)
                    {
                        isChanged = true;
                        movePos = movePath[indexPos].position;
                        indexPos++;
                    }
                    break;
            }
        }
        else
        {
            isChanged = false;
        }

        if (!isHaveTalk) return; // ���û�жԻ���ִ�������
        if (isCanShow && panDialogue.gameObject.activeSelf)
            aim.SetBool("IsTalking", true);

        // ����Ƿ������ʾ�Ի����������Ի�
        if (isHaveTalk && isCanShow && Input.GetKeyDown(KeyCode.Q) && !panDialogue.gameObject.activeSelf)
        {
            nav.isStopped = true;
            panDialogue.textFile = asset;
            panDialogue.gameObject.SetActive(true);
        }
        
    }

    // ����ҽ��봥������Χʱ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //if (isHaveTalk)
            //    panTipKeyDown.SetActive(true);
            if (!isTalking && isHaveTalk)
            {
                currentDialoguePanel = panDialogue;
                isCanShow = true;
                isTalking = true;
                panTipKeyDown.SetActive(true);
            }
        }
    }

    // ������ڴ�������Χ��ʱ��������
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //if (isHaveTalk)
            //    isCanShow = true;
            if (isHaveTalk)
            {
                if (currentDialoguePanel != null && currentDialoguePanel.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Q))
                {
                    currentDialoguePanel.StopCurrentDialogue(); // ֹͣ��ǰ�Ի�
                    currentDialoguePanel.gameObject.SetActive(false); // �رյ�ǰ�Ի����
                    panTipKeyDown.SetActive(false); // �رյ�ǰ������ʾ
                }

                currentDialoguePanel = panDialogue; // ���µ�ǰ�Ի����Ϊ�µĶԻ����
                isCanShow = true; // ������ʾ�µĶԻ�
            }
        }
    }

    // ������뿪��������Χʱ����
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //if (!isHaveTalk) return;

            //panTipKeyDown.SetActive(false);
            //nav.isStopped = false;
            //aim.SetBool("IsTalking", false);
            //panDialogue.gameObject.SetActive(false);
            if (isHaveTalk)
            {
                isCanShow = false;
                isTalking = false;
                panTipKeyDown.SetActive(false);
                nav.isStopped = false;
                aim.SetBool("IsTalking", false);
                panDialogue.gameObject.SetActive(false);
            }
        }
    }
}

// �ƶ�����ö�٣�����ƶ��򰴹̶�·���ƶ�
public enum MoveType
{
    RandomMv,
    LineMv
}


