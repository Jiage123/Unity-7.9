using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


public class NpcMovent : MonoBehaviour
{

    public bool isHaveTalk; //必须设置-是否有对话
    public List<Transform> movePath; // 移动的路径
    public MoveType moveType; // 移动的类型-固定路径-随机路径
    public GameObject panTipKeyDown; // 提示按下按键文本
    public DialogWith panDialogue; // 对话的面板
    public TextAsset asset; //对话的文件

    private NavMeshAgent nav;
    private Animator aim;
    private bool isCanShow; // 是否能显示对话
    private Vector3 movePos; // 移动的目标点
    private int indexPos = 0;
    private bool isChanged;

    private DialogWith currentDialoguePanel; // 用于跟踪当前的对话面板
    
    private bool isTalking = false;// 是否正在对话中

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
        // 根据移动类型更新目标点
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

        if (!isHaveTalk) return; // 如果没有对话则不执行下面的
        if (isCanShow && panDialogue.gameObject.activeSelf)
            aim.SetBool("IsTalking", true);

        // 检查是否可以显示对话，并触发对话
        if (isHaveTalk && isCanShow && Input.GetKeyDown(KeyCode.Q) && !panDialogue.gameObject.activeSelf)
        {
            nav.isStopped = true;
            panDialogue.textFile = asset;
            panDialogue.gameObject.SetActive(true);
        }
        
    }

    // 当玩家进入触发器范围时触发
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

    // 当玩家在触发器范围内时持续触发
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
                    currentDialoguePanel.StopCurrentDialogue(); // 停止当前对话
                    currentDialoguePanel.gameObject.SetActive(false); // 关闭当前对话面板
                    panTipKeyDown.SetActive(false); // 关闭当前按键提示
                }

                currentDialoguePanel = panDialogue; // 更新当前对话面板为新的对话面板
                isCanShow = true; // 可以显示新的对话
            }
        }
    }

    // 当玩家离开触发器范围时触发
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

// 移动类型枚举：随机移动或按固定路径移动
public enum MoveType
{
    RandomMv,
    LineMv
}


