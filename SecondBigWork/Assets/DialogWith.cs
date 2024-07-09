using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogWith : MonoBehaviour
{
    public float txtSpeed; // �ı���ʾ�ٶ�
    public Text txtLable; // ������ʾ�ı���UI Text���
    public TextAsset textFile;// �洢�Ի��ı����ı��ļ�
    public int index; // ��ǰ�Ի�����
    public List<string> txtList = new List<string>();// �洢�Ի��ı����б�

    private bool isOver;// �Ի��Ƿ�����ı�־
    private bool isCancelTyping;// �Ƿ�ȡ������Ч���ı�־

    public Transform player;
    private Animator aim;

    void Start()
    {
        aim = this.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        PlayerController.isCanMove = false;// ��ֹ����ƶ�
        player.GetComponent<Animator>().enabled = false;//�Ի�ʱ��Ҷ�����ֹ
        GetTxtFromFile(textFile);// ���ı��ļ��л�ȡ�Ի�����
        txtList.RemoveAt(0);// �Ƴ���һ�У������Ǳ���ȣ�
        txtLable.text = txtList[index];// ��ʾ��ǰ�Ի�����
        index++;
        isOver = true;
    }

    void Update()
    {
        // �������R���ҶԻ��Ѿ���������رնԻ���
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
                StartCoroutine(SetPrintTxt());// ��ʼ������ʾ�ı�
            }
            else if(!isOver)
            {
                isCancelTyping = !isCancelTyping;
            }
        }

    }

    private void OnDisable()
    {
        PlayerController.isCanMove = true;// ��������ƶ�
        player.GetComponent<Animator>().enabled = true;//�Ի�ʱ��Ҷ����ָ�
        isOver = true; // ���öԻ�״̬
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
            txtLable.text += txtList[index].Split(",")[1][strOne];// ������ʾ�ı�
            strOne++;
            yield return new WaitForSeconds(0.2f);// �ȴ�һ��ʱ������ʾ��һ����
        }
        txtLable.text = txtList[index].Split(",")[1];// ��ʾ�����ı�
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
            txtList.Add(line);// ���ı��ļ��е�ÿһ����ӵ��Ի��ı��б���

    }
}
