using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogWith : MonoBehaviour
{
    public float txtSpeed; // 文本显示速度
    public Text txtLable; // 用于显示文本的UI Text组件
    public TextAsset textFile;// 存储对话文本的文本文件
    public int index; // 当前对话索引
    public List<string> txtList = new List<string>();// 存储对话文本的列表

    private bool isOver;// 对话是否结束的标志
    private bool isCancelTyping;// 是否取消打字效果的标志

    public Transform player;
    private Animator aim;

    void Start()
    {
        aim = this.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        PlayerController.isCanMove = false;// 禁止玩家移动
        player.GetComponent<Animator>().enabled = false;//对话时玩家动画禁止
        GetTxtFromFile(textFile);// 从文本文件中获取对话内容
        txtList.RemoveAt(0);// 移除第一行（可能是标题等）
        txtLable.text = txtList[index];// 显示当前对话内容
        index++;
        isOver = true;
    }

    void Update()
    {
        // 如果按下R键且对话已经结束，则关闭对话框
        if (Input.GetKeyDown(KeyCode.R) && index == txtList.Count)
        {
            this.gameObject.SetActive(false);
            index = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isOver && !isCancelTyping)
            {
                StartCoroutine(SetPrintTxt());// 开始逐字显示文本
            }
            else if(!isOver)
            {
                isCancelTyping = !isCancelTyping;
            }
        }

    }

    private void OnDisable()
    {
        PlayerController.isCanMove = true;// 允许玩家移动
        player.GetComponent<Animator>().enabled = true;//对话时玩家动画恢复
        isOver = true; // 重置对话状态
    }

    public void StopCurrentDialogue()
    {
        StopCoroutine(SetPrintTxt());
        isOver = true;
        isCancelTyping = false;
        txtLable.text = "";
    }

    IEnumerator SetPrintTxt()
    {
        isOver = false;
        txtLable.text = "";
        int strOne = 0;
        while (!isCancelTyping && strOne < txtList[index].Split(",")[1].Length -1)
        {
            txtLable.text += txtList[index].Split(",")[1][strOne];// 逐字显示文本
            strOne++;
            yield return new WaitForSeconds(0.2f);// 等待一段时间再显示下一个字
        }
        txtLable.text = txtList[index].Split(",")[1];// 显示完整文本
        isCancelTyping = false;
        isOver = true;
        index++;

    }

    void GetTxtFromFile(TextAsset textFile)
    {
        txtList.Clear();
        index = 0;
        var lineData =  textFile.text.Split('\n');
        foreach (var line in lineData)
            txtList.Add(line);// 将文本文件中的每一行添加到对话文本列表中

    }
}
